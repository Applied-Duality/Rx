﻿/// <reference path="../reactiveassert.js" />
/// <reference path="../rx.js" />
/// <reference path="../rx.testing.js" />

(function(window) {

    // Check if browser vs node
    var root;
    if (!window.document) {
        root = require('../rx.js');
        require('../rx.testing');
        require('./ReactiveAssert');
    } else {
        root = window.Rx;
    }

    // use a single load function
    var load = typeof require == 'function' ? require : window.load;

    // load QUnit and CLIB if needed
    var QUnit =
      window.QUnit || (
        window.setTimeout || (window.addEventListener = window.setTimeout = / /),
        window.QUnit = load('./vendor/qunit-1.9.0.js') || window.QUnit,
        load('./vendor/qunit-clib.js'),
        (window.addEventListener || 0).test && delete window.addEventListener,
        window.QUnit
      );

    QUnit.module('VirtualSchedulerTest');

    var VirtualTimeScheduler = root.VirtualTimeScheduler;

    var VirtualSchedulerTestScheduler = (function () {

        function comparer(a, b) {
            if (a === b) {
                return 0;
            }
            if (a < b) {
                return -1;
            }
            return 1;
        }

        function add(absolute, relative) {
            if (absolute === null) {
                absolute = '';
            }
            return absolute + relative;
        }

        function toDateTimeOffset(absolute) {
            if (absolute === null) {
                absolute = '';
            }
            return new Date(absolute.length);
        }

        function toRelative(timespan) {
            return String.fromCharCode(timeSpan % 65535);
        }

        return function () {
            var scheduler = new VirtualTimeScheduler(null, comparer);
            scheduler.add = add.bind(scheduler);
            scheduler.toDateTimeOffset = toDateTimeOffset.bind(scheduler);
            scheduler.toRelative = toRelative.bind(scheduler);
            return scheduler;
        };
    }());

    test('Virtual_Now', function () {
        var res;
        res = new VirtualSchedulerTestScheduler().now() - new Date().getTime();
        ok(res < 1000);
    });

    test('Virtual_ScheduleAction', function () {
        var ran, scheduler;
        ran = false;
        scheduler = new VirtualSchedulerTestScheduler();
        scheduler.schedule(function () {
            ran = true;
        });
        scheduler.start();
        ok(ran);
    });

    test('Virtual_ScheduleActionError', function () {
        var ex, scheduler;
        ex = 'ex';
        try {
            scheduler = new VirtualSchedulerTestScheduler();
            scheduler.schedule(function () {
                throw ex;
            });
            scheduler.start();
            ok(false);
        } catch (e) {
            equal(e, ex);
        }
    });

    // must call `QUnit.start()` if using QUnit < 1.3.0 with Node.js or any
    // version of QUnit with Narwhal, Rhino, or RingoJS
    if (!window.document) {
        QUnit.start();
    }
}(typeof global == 'object' && global || this));