    // Notifications

    var Notification = root.Notification = (function () {
        function Notification() { }

        addProperties(Notification.prototype, {
            /// <summary>
            /// Invokes the delegate corresponding to the notification or an observer and returns the produced result.
            /// &#10;
            /// &#10;1 - notification.accept(observer);
            /// &#10;2 - notification.accept(onNext, onError, onCompleted);
            /// </summary>
            /// <param name="observerOrOnNext">Delegate to invoke for an OnNext notification.</param>
            /// <param name="onError">[Optional] Delegate to invoke for an OnError notification.</param>
            /// <param name="onCompleted">[Optional] Delegate to invoke for an OnCompleted notification.</param>
            /// <returns>Result produced by the observation.</returns>
            accept: function (observerOrOnNext, onError, onCompleted) {
                if (arguments.length > 1 || typeof observerOrOnNext === 'function') {
                    return this._accept(observerOrOnNext, onError, onCompleted);
                } else {
                    return this._acceptObservable(observerOrOnNext);
                }
            },
            toObservable: function (scheduler) {
                /// <summary>
                /// Returns an observable sequence with a single notification, using the specified scheduler, else the immediate scheduler.
                /// </summary>
                /// <param name="scheduler">[Optional] Scheduler to send out the notification calls on.</param>
                /// <returns>The observable sequence that surfaces the behavior of the notification upon subscription.</returns>
                var notification = this;
                scheduler = scheduler || immediateScheduler;
                return new AnonymousObservable(function (observer) {
                    return scheduler.schedule(function () {
                        notification._acceptObservable(observer);
                        if (notification.kind === 'N') {
                            observer.onCompleted();
                        }
                    });
                });
            },
            hasValue: false,
            equals: function (other) {
                /// <summary>
                /// Indicates whether this instance and a specified object are equal.
                /// </summary>
                /// <returns>true if both objects are the same; false otherwise.</returns>
                var otherString = other == null ? '' : other.toString();
                return this.toString() === otherString;
            }
        });

        return Notification;
    })();

    var notificationCreateOnNext = Notification.createOnNext = (function () {
        inherits(ON, Notification);
        function ON(value) {
            this.value = value;
            this.hasValue = true;
            this.kind = 'N';
        }

        addProperties(ON.prototype, {
            _accept: function (onNext) {
                return onNext(this.value);
            },
            _acceptObservable: function (observer) {
                return observer.onNext(this.value);
            },
            toString: function () {
                return 'OnNext(' + this.value + ')';
            }
        });

        return function (next) {
            return new ON(next);
        };
    }());

    var notificationCreateOnError = Notification.createOnError = (function () {
        inherits(OE, Notification);
        function OE(exception) {
            this.exception = exception;
            this.kind = 'E';
        }

        addProperties(OE.prototype, {
            _accept: function (onNext, onError) {
                return onError(this.exception);
            },
            _acceptObservable: function (observer) {
                return observer.onError(this.exception);
            },
            toString: function () {
                return 'OnError(' + this.exception + ')';
            }
        });

        return function (error) {
            return new OE(error);
        };
    }());

    var notificationCreateOnCompleted = Notification.createOnCompleted = (function () {
        inherits(OC, Notification);
        function OC() {
            this.kind = 'C';
        }

        addProperties(OC.prototype, {
            _accept: function (onNext, onError, onCompleted) {
                return onCompleted();
            },
            _acceptObservable: function (observer) {
                return observer.onCompleted();
            },
            toString: function () {
                return 'OnCompleted()';
            }
        });

        return function () {
            return new OC();
        };
    }());
