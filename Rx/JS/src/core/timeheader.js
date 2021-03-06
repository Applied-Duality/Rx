    // Refernces
    var Observable = root.Observable,
        observableProto = Observable.prototype,
        AnonymousObservable = root.Internals.AnonymousObservable,
        observableDefer = Observable.defer,
        observableEmpty = Observable.empty,
        observableThrow = Observable.throwException,
        observableFromArray = Observable.fromArray,
        timeoutScheduler = root.Scheduler.timeout,
        SingleAssignmentDisposable = root.SingleAssignmentDisposable,
        SerialDisposable = root.SerialDisposable,
        CompositeDisposable = root.CompositeDisposable,
        RefCountDisposable = root.RefCountDisposable,
        Subject = root.Subject,
        BinaryObserver = root.Internals.BinaryObserver,
        addRef = root.Internals.addRef,
        normalizeTime = root.Scheduler.normalize;
