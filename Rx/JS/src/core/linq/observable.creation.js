    /**
     *  Creates an observable sequence from a specified subscribe method implementation.
     *  
     *  1 - res = Rx.Observable.create(function (observer) { return function () { } );
     *  
     *  @param subscribe Implementation of the resulting observable sequence's subscribe method, returning a function that will be wrapped in a Disposable.
     *  @return The observable sequence with the specified implementation for the Subscribe method.
     */
    Observable.create = function (subscribe) {
        return new AnonymousObservable(function (o) {
            return disposableCreate(subscribe(o));
        });
    };

    /**
     *  Creates an observable sequence from a specified subscribe method implementation.
     *  
     *  1 - res = Rx.Observable.create(function (observer) { return Rx.Disposable.empty; } );        
     *  
     *  @param subscribe Implementation of the resulting observable sequence's subscribe method.
     *  @return The observable sequence with the specified implementation for the Subscribe method.
     */
    Observable.createWithDisposable = function (subscribe) {
        return new AnonymousObservable(subscribe);
    };

    /**
     *  Returns an observable sequence that invokes the specified factory function whenever a new observer subscribes.
     *  
     *  1 - res = Rx.Observable.defer(function () { return Rx.Observable.fromArray([1,2,3]); });    
     *  
     *  @param observableFactory Observable factory function to invoke for each observer that subscribes to the resulting sequence.
     *  @return An observable sequence whose observers trigger an invocation of the given observable factory function.
     */
    var observableDefer = Observable.defer = function (observableFactory) {
        return new AnonymousObservable(function (observer) {
            var result;
            try {
                result = observableFactory();
            } catch (e) {
                return observableThrow(e).subscribe(observer);
            }
            return result.subscribe(observer);
        });
    };

    /**
     *  Returns an empty observable sequence, using the specified scheduler to send out the single OnCompleted message.
     *  
     *  1 - res = Rx.Observable.empty();  
     *  2 - res = Rx.Observable.empty(Rx.Scheduler.timeout);  
     *  
     *  @param scheduler Scheduler to send the termination call on.
     *  @return An observable sequence with no elements.
     */
    var observableEmpty = Observable.empty = function (scheduler) {
        scheduler || (scheduler = immediateScheduler);
        return new AnonymousObservable(function (observer) {
            return scheduler.schedule(function () {
                observer.onCompleted();
            });
        });
    };

    /**
     *  Converts an array to an observable sequence, using an optional scheduler to enumerate the array.
     *  
     *  1 - res = Rx.Observable.fromArray([1,2,3]);
     *  2 - res = Rx.Observable.fromArray([1,2,3], Rx.Scheduler.timeout);
     *  
     *  @param scheduler [Optional] Scheduler to run the enumeration of the input sequence on.
     *  @return The observable sequence whose elements are pulled from the given enumerable sequence.
     */
    var observableFromArray = Observable.fromArray = function (array, scheduler) {
        scheduler || (scheduler = currentThreadScheduler);
        return new AnonymousObservable(function (observer) {
            var count = 0;
            return scheduler.scheduleRecursive(function (self) {
                if (count < array.length) {
                    observer.onNext(array[count++]);
                    self();
                } else {
                    observer.onCompleted();
                }
            });
        });
    };

    /**
     *  Generates an observable sequence by running a state-driven loop producing the sequence's elements, using the specified scheduler to send out observer messages.
     *  
     *  1 - res = Rx.Observable.generate(0, function (x) { return x < 10; }, function (x) { return x + 1; }, function (x) { return x; });
     *  2 - res = Rx.Observable.generate(0, function (x) { return x < 10; }, function (x) { return x + 1; }, function (x) { return x; }, Rx.Scheduler.timeout);
     *  
     *  @param initialState Initial state.
     *  @param condition Condition to terminate generation (upon returning false).
     *  @param iterate Iteration step function.
     *  @param resultSelector Selector function for results produced in the sequence.
     *  @param scheduler [Optional] Scheduler on which to run the generator loop. If not provided, defaults to Scheduler.currentThread.
     *  @return The generated sequence.
     */
    Observable.generate = function (initialState, condition, iterate, resultSelector, scheduler) {
        scheduler || (scheduler = currentThreadScheduler);
        return new AnonymousObservable(function (observer) {
            var first = true, state = initialState;
            return scheduler.scheduleRecursive(function (self) {
                var hasResult, result;
                try {
                    if (first) {
                        first = false;
                    } else {
                        state = iterate(state);
                    }
                    hasResult = condition(state);
                    if (hasResult) {
                        result = resultSelector(state);
                    }
                } catch (exception) {
                    observer.onError(exception);
                    return;
                }
                if (hasResult) {
                    observer.onNext(result);
                    self();
                } else {
                    observer.onCompleted();
                }
            });
        });
    };

    /**
     *  Returns a non-terminating observable sequence, which can be used to denote an infinite duration (e.g. when using reactive joins).
     *  
     *  @return An observable sequence whose observers will never get called.
     */
    var observableNever = Observable.never = function () {
        return new AnonymousObservable(function () {
            return disposableEmpty;
        });
    };

    /**
     *  Generates an observable sequence of integral numbers within a specified range, using the specified scheduler to send out observer messages.
     *  
     *  1 - res = Rx.Observable.range(0, 10);
     *  2 - res = Rx.Observable.range(0, 10, Rx.Scheduler.timeout);
     *  
     *  @param start The value of the first integer in the sequence.
     *  @param count The number of sequential integers to generate.
     *  @param scheduler [Optional] Scheduler to run the generator loop on. If not specified, defaults to Scheduler.currentThread.
     *  @return An observable sequence that contains a range of sequential integral numbers.
     */
    Observable.range = function (start, count, scheduler) {
        scheduler || (scheduler = currentThreadScheduler);
        return new AnonymousObservable(function (observer) {
            return scheduler.scheduleRecursiveWithState(0, function (i, self) {
                if (i < count) {
                    observer.onNext(start + i);
                    self(i + 1);
                } else {
                    observer.onCompleted();
                }
            });
        });
    };

    /**
     *  Generates an observable sequence that repeats the given element the specified number of times, using the specified scheduler to send out observer messages.
     *  
     *  1 - res = Rx.Observable.repeat(42);
     *  2 - res = Rx.Observable.repeat(42, 4);
     *  3 - res = Rx.Observable.repeat(42, 4, Rx.Scheduler.timeout);
     *  4 - res = Rx.Observable.repeat(42, null, Rx.Scheduler.timeout);
     *  
     *  @param value Element to repeat.
     *  @param repeatCount [Optiona] Number of times to repeat the element. If not specified, repeats indefinitely.
     *  @param scheduler Scheduler to run the producer loop on. If not specified, defaults to Scheduler.immediate.
     *  @return An observable sequence that repeats the given element the specified number of times.
     */
    Observable.repeat = function (value, repeatCount, scheduler) {
        scheduler || (scheduler = currentThreadScheduler);
        if (repeatCount == undefined) {
            repeatCount = -1;
        }
        return observableReturn(value, scheduler).repeat(repeatCount);
    };

    /**
     *  Returns an observable sequence that contains a single element, using the specified scheduler to send out observer messages.
     *  
     *  1 - res = Rx.Observable.returnValue(42);
     *  2 - res = Rx.Observable.returnValue(42, Rx.Scheduler.timeout);
     *  
     *  @param value Single element in the resulting observable sequence.
     *  @param scheduler Scheduler to send the single element on. If not specified, defaults to Scheduler.immediate.
     *  @return An observable sequence containing the single specified element.
     */
    var observableReturn = Observable.returnValue = function (value, scheduler) {
        scheduler || (scheduler = immediateScheduler);
        return new AnonymousObservable(function (observer) {
            return scheduler.schedule(function () {
                observer.onNext(value);
                observer.onCompleted();
            });
        });
    };

    /**
     *  Returns an observable sequence that terminates with an exception, using the specified scheduler to send out the single OnError message.
     *  
     *  1 - res = Rx.Observable.throwException(new Error('Error'));
     *  2 - res = Rx.Observable.throwException(new Error('Error'), Rx.Scheduler.timeout);
     *  
     *  @param exception An object used for the sequence's termination.
     *  @param scheduler Scheduler to send the exceptional termination call on. If not specified, defaults to Scheduler.immediate.
     *  @return The observable sequence that terminates exceptionally with the specified exception object.
     */
    var observableThrow = Observable.throwException = function (exception, scheduler) {
        scheduler || (scheduler = immediateScheduler);
        return new AnonymousObservable(function (observer) {
            return scheduler.schedule(function () {
                observer.onError(exception);
            });
        });
    };

    /**
     *  Constructs an observable sequence that depends on a resource object, whose lifetime is tied to the resulting observable sequence's lifetime.
     *  
     *  1 - res = Rx.Observable.using(function () { return new AsyncSubject(); }, function (s) { return s; });
     *  
     *  @param resourceFactory Factory function to obtain a resource object.
     *  @param observableFactory Factory function to obtain an observable sequence that depends on the obtained resource.
     *  @return An observable sequence whose lifetime controls the lifetime of the dependent resource object.
     */
    Observable.using = function (resourceFactory, observableFactory) {
        return new AnonymousObservable(function (observer) {
            var disposable = disposableEmpty, resource, source;
            try {
                resource = resourceFactory();
                if (resource) {
                    disposable = resource;
                }
                source = observableFactory(resource);
            } catch (exception) {
                return new CompositeDisposable(observableThrow(exception).subscribe(observer), disposable);
            }
            return new CompositeDisposable(source.subscribe(observer), disposable);
        });
    };                        