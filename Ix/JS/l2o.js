/*

Copyright (c) Microsoft Open Technologies, Inc.  All rights reserved.
Microsoft Open Technologies would like to thank its contributors, a list
of whom are at http://aspnetwebstack.codeplex.com/wikipage?title=Contributors.

Licensed under the Apache License, Version 2.0 (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied. See the License for the specific language governing permissions
and limitations under the License.
*/

(function (window, undefined) {
    var freeExports = typeof exports == 'object' && exports &&
        (typeof global == 'object' && global && global == global.global && (window = global), exports);    

    var root = {};

    function noop () {}
    function identity (x) { return x; }
    function defaultComparer (x, y) { return x > y ? 1 : x < y ? -1 : 0; }
    function defaultEqualityComparer (x, y) { return x === y; }
    function defaultSerializer (x) { return x.toString(); };

    var slice = Array.prototype.slice;
    var outOfRange = 'Index out of range';
    var seqNoElements = 'Sequence contains no elements.';
    var invalidOperation = 'Invalid operation';         

    var hasProp = {}.hasOwnProperty;
    function inherits (child, parent) {
        for (var key in parent) {
            if (key !== 'prototype' && hasProp.call(parent, key)) child[key] = parent[key];
        }
        function ctor() { this.constructor = child; }
        ctor.prototype = parent.prototype;
        child.prototype = new ctor();
        child.super_ = parent.prototype;
        return child;
    }

    var Enumerator = root.Enumerator = function (moveNext, getCurrent, dispose) {
        this.moveNext = moveNext;
        this.getCurrent = getCurrent;
        this.dispose = dispose;
    };

    var enumeratorCreate = Enumerator.create = function (moveNext, getCurrent, dispose) {
        var done = false;
        dispose || (dispose = noop);
        return new Enumerator(function () {
            if (done) {
                return false;
            }
            var result = moveNext();
            if (!result) {
                done = true;
                dispose();
            }
            return result;
        }, function () { return getCurrent(); }, function () {
            if (!done) {
                dispose();
                done = true;
            }
        });
    };

    var Enumerable = root.Enumerable = (function () {
        function Enumerable(getEnumerator) {
            this.getEnumerator = getEnumerator;
        }

        var EnumerablePrototype = Enumerable.prototype;

        function aggregate (seed, func, resultSelector) {
            resultSelector || (resultSelector = identity);
            var accumulate = seed, enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    accumulate = func(accumulate, enumerator.getCurrent());
                }
            } finally {
                enumerator.dispose();
            }
            return resultSelector ? resultSelector(accumulate) : accumulate;         
        }

        function aggregate1 (func) {
            var accumulate, enumerator = this.getEnumerator();
            try {
                if (!enumerator.moveNext()) {
                    throw new Error(seqNoElements);
                }
                accumulate = enumerator.getCurrent();
                while (enumerator.moveNext()) {
                    accumulate = func(accumulate, enumerator.getCurrent());
                }
            } finally {
                enumerator.dispose();
            }
            return accumulate;
        }

        EnumerablePrototype.aggregate = function(/* seed, func, resultSelector */) {
            var f = arguments.length === 1 ? aggregate1 : aggregate;
            return f.apply(this, arguments);
        };

        EnumerablePrototype.all = function (predicate) {
            var enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    if (!predicate(enumerator.getCurrent())) {
                        return false;
                    }
                }
            } finally {
                enumerator.dispose();
            }
            return true;
        }; 

        EnumerablePrototype.any = function(predicate) {
            var enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    if (!predicate || predicate(enumerator.getCurrent())) {
                        return true;
                    }
                }
            } finally {
                enumerator.dispose();
            }
            return false;   
        }; 

        EnumerablePrototype.average = function(selector) {
            if (selector) {
                return this.select(selector).average();
            }
            var enumerator = this.getEnumerator(), count = 0, sum = 0;
            try {
                while (enumerator.moveNext()) {
                    count++;
                    sum += enumerator.getCurrent();
                }
            } finally {
                enumerator.dispose();
            }
            if (count === 0) {
                throw new Error(seqNoElements);
            }
            return sum / count;
        };        

        EnumerablePrototype.concat = function () {
            var args = slice.call(arguments, 0);
            args.unshift(this);
            return enumerableConcat.apply(null, args);
        };

        EnumerablePrototype.contains = function(value, comparer) {
            comparer || (comparer = defaultEqualityComparer); 
            var enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    if (comparer(value, enumerator.getCurrent())) {
                        return true;
                    }
                }
            } finally {
                enumerator.dispose();
            }
            return false;
        };

        EnumerablePrototype.count = function(predicate) {
            var c = 0, enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    if (!predicate || predicate(enumerator.getCurrent())) {
                        c++;
                    }
                }
            } finally {
                enumerator.dispose();
            }
            return c;       
        };

        EnumerablePrototype.defaultIfEmpty = function(defaultValue) {
            var parent = this;
            return new Enumerable(function () {
                var current, hasValue = false, enumerator;
                return enumeratorCreate(
                    function () {
                        enumerator || (enumerator = parent.getEnumerator());
                        if (!enumerator.moveNext()) {
                            return false;
                        }
                        hasValue = true;
                        current = enumerator.getCurrent();
                        return true;
                    },
                    function () {
                        if (!hasValue) {
                            return defaultValue;
                        }
                        return current;
                    },
                    function () { enumerator.dispose(); }
                );
            });
        };

        function arrayIndexOf (item, comparer) {
            comparer || (comparer = defaultComparer);
            var idx = this.length;
            while (idx--) {
                if (comparer(this[idx], item)) {
                    return idx;
                }
            }
            return -1;
        }

        function arrayRemove(item, comparer) {
            var idx = arrayIndexOf.call(this, item, comparer);
            if (idx === -1) { 
                return false;
            }
            this.splice(idx, 1);
            return true;
        }
        
        EnumerablePrototype.distinct = function(comparer) {
            comparer || (comparer = defaultEqualityComparer);
            var parent = this;
            return Enumerable(function () {
                var current, map = [], enumerator;
                return enumeratorCreate(
                    function () {
                        enumerator || (enumerator = parent.getEnumerator());
                        while (true) {
                            if (!enumerator.moveNext()) {
                                return false;
                            }
                            current = enumerator.getCurrent();
                            if (arrayIndexOf.call(map, current, comparer) === -1) {
                                map.push(current);
                                return true;
                            }
                        }
                    },
                    function () { return current; },
                    function () { enumerator.dispose(); }
                );
            });
        };

        EnumerablePrototype.elementAt = function (index) {
            return this.skip(index).first();
        };

        EnumerablePrototype.elementAtOrDefault = function (index) {
            return this.skip(index).firstOrDefault();
        };

        EnumerablePrototype.except = function(second, comparer) {
            comparer || (comparer = defaultEqualityComparer);
            var parent = this;
            return new Enumerable(function () {
                var current, map = [], firstEnumerator = parent.getEnumerator(), secondEnumerator;
                while (firstEnumerator.moveNext()) {
                    map.push(firstEnumerator.getCurrent());
                }
                return enumeratorCreate(
                    function () {
                        secondEnumerator || (secondEnumerator = second.getEnumerator());
                        while (true) {
                            if (!secondEnumerator.moveNext()) {
                                return false;
                            }
                            current = secondEnumerator.getCurrent();
                            if (arrayIndexOf.call(map, current, comparer) === -1) {
                                map.push(current);
                                return true;
                            }
                        }
                    },
                    function () { return current; },
                    function () { enumerator.dispose(); }
                );
            });
        };        

        EnumerablePrototype.first = function (predicate) {
            var enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    var current = enumerator.getCurrent();
                    if (!predicate || predicate(current))
                        return current;
                }
            } finally {
                enumerator.dispose();
            }       
            throw new Error(seqNoElements);
        };

        EnumerablePrototype.firstOrDefault = function (predicate) {
            var enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    var current = enumerator.getCurrent();
                    if (!predicate || predicate(current)) {
                        return current;
                    }
                }
            } finally {
                enumerator.dispose();
            }       
            return null;
        };

        EnumerablePrototype.forEach = function (action) {
            var e = this.getEnumerator(),
                i = 0;
            try {
                while (e.moveNext()) {
                    action(e.getCurrent(), i++);
                }
            } finally {
                e.dispose();
            }
        }; 

        EnumerablePrototype.groupBy = function (keySelector, elementSelector, resultSelector, keySerializer) {
            elementSelector || (elementSelector = identity);
            keySerializer || (keySerializer = defaultSerializer);
            var parent = this;
            return new Enumerable(function () {
                var map = {}, keys = [], index = 0, value, key,
                    parentEnumerator = parent.getEnumerator(), 
                    parentCurrent,
                    parentKey,
                    parentSerialized,
                    parentElement;
                while (parentEnumerator.moveNext()) {
                    parentCurrent = parentEnumerator.getCurrent();
                    parentKey = keySelector(parentCurrent);
                    parentSerialized = keySerializer(parentKey);
                    if (!map[parentSerialized]) {
                        map[parentSerialized] = [];
                        keys.push(parentSerialized);
                    }
                    parentElement = elementSelector(parentCurrent);
                    map[parentSerialized].push(parentElement);
                }
                return enumeratorCreate(
                    function () {
                        var values;
                        if (index < keys.length) {
                            key = keys[index++];
                            values = enumerableFromArray(map[key]);
                            if (!resultSelector) {
                                values.key = key;
                                value = values;
                            } else {
                                value = resultSelector(key, values);
                            }
                            return true;
                        }
                        return false;
                    },
                    function () { return value; }
                );
            });
        };

        EnumerablePrototype.intersect = function(second, comparer) {
            comparer || (comparer = defaultEqualityComparer);
            var parent = this;
            return new Enumerable(function () {
                var current,  map = [], firstEnumerator = parent.getEnumerator(), secondEnumerator;
                while (firstEnumerator.moveNext()) {
                    map.push(firstEnumerator.getCurrent());
                }
                return enumeratorCreate(
                    function () {
                        secondEnumerator || (secondEnumerator = second.getEnumerator());
                        while (true) {
                            if (!secondEnumerator.moveNext()) {
                                return false;
                            }
                            current = secondEnumerator.getCurrent();
                            if (arrayRemove.call(map, current, comparer)) {
                                return true;
                            }
                        }
                    },
                    function () {
                        return current;
                    },
                    function () {
                        enumerator.dispose();
                    }
                );
            });
        };

        EnumerablePrototype.last = function (predicate) {
            var hasValue = false, value, enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    var current = enumerator.getCurrent();
                    if (!predicate || predicate(current)) {
                        hasValue = true;
                        value = current;
                    }
                }
            } finally {
                enumerator.dispose();
            }       
            if (hasValue) {
                return value;
            }
            throw new Error(seqNoElements);
        };

        EnumerablePrototype.lastOrDefault = function (predicate) {
            var hasValue = false, value, enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    var current = enumerator.getCurrent();
                    if (!predicate || predicate(current)) {
                        hasValue = true;
                        value = current;
                    }
                }
            } finally {
                enumerator.dispose();
            }

            return hasValue ? value : null;
        };

        EnumerablePrototype.max = function(selector) {
            if(selector) {
                return this.select(selector).max();
            }       
            var m, hasElement = false, enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    var x = enumerator.getCurrent();
                    if (!hasElement) {
                        m = x;
                        hasElement = true;
                    } else {
                        if (x > m) {
                            m = x;
                        }
                    }
                }
            } finally {
                enumerator.dispose();
            }
            if(!hasElement) {
                throw new Error(seqNoElements);
            }
            return m;
        };        

        EnumerablePrototype.min = function(selector) {
            if(selector) {
                return this.select(selector).min();
            }       
            var m, hasElement = false, enumerator = this.getEnumerator();
            try {
                while(enumerator.moveNext()) {
                    var x = enumerator.getCurrent();
                    if (!hasElement) {
                        m = x;
                        hasElement = true;
                    } else {
                        if (x < m) {
                            m = x;
                        }
                    }
                }
            } finally {
                enumerator.dispose();
            }
            if(!hasElement) {
                throw new Error(seqNoElements);
            }
            return m;
        };         

        EnumerablePrototype.orderBy = function (keySelector, comparer) {
            return new OrderedEnumerable(this, keySelector, comparer, false);
        };

        EnumerablePrototype.orderByDescending = function (keySelector, comparer) {
            return new OrderedEnumerable(this, keySelector, comparer, true);
        };

        EnumerablePrototype.reverse = function () {
            var arr = [], enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    arr.unshift(enumerator.getCurrent());
                }
            } finally {
                enumerator.dispose();
            }
            return enumerableFromArray(arr);
        };        

        EnumerablePrototype.select = function (selector) {
            var parent = this;
            return new Enumerable(function () {
                var current, index = 0, enumerator;
                return enumeratorCreate(
                    function () {
                        enumerator || (enumerator = parent.getEnumerator());
                        if (!enumerator.moveNext()) {
                            return false;
                        }
                        current = selector(enumerator.getCurrent(), index++);
                        return true;
                    },
                    function () { return current; },
                    function () { enumerator.dispose(); }
                );
            });
        };

        EnumerablePrototype.selectMany = function (collectionSelector, resultSelector) {
            var parent = this;
            return new Enumerable(function () {
                var current, index = 0, outerEnumerator, innerEnumerator;
                return enumeratorCreate(
                    function () {
                        outerEnumerator || (outerEnumerator = parent.getEnumerator());
                        while (true) {
                            if (!innerEnumerator) {
                                if (!outerEnumerator.moveNext()) {
                                    return false;
                                }

                                innerEnumerator = collectionSelector(outerEnumerator.getCurrent()).getEnumerator();
                            }
                            if (innerEnumerator.moveNext()) {
                                current = innerEnumerator.getCurrent();
                                
                                if (resultSelector) {
                                    var o = outerEnumerator.getCurrent();
                                    current = resultSelector(o, current);
                                }

                                return true;
                            } else {
                                innerEnumerator.dispose();
                                innerEnumerator = null;
                            }
                        }
                    },
                    function () { return current; },
                    function () {
                        if (innerEnumerator) {
                            innerEnumerator.dispose();
                        }
                        outerEnumerator.dispose();   
                    }
                );
            });
        };

        EnumerablePrototype.sequenceEqual = function (second, comparer) {
            comparer || (comparer = defaultEqualityComparer);
            var e1 = this.getEnumerator(), e2 = second.getEnumerator();
            try {
                while (e1.moveNext()) {
                    if (!e2.moveNext() || ! comparer(e1.getCurrent(), e2.getCurrent())) {
                        return false;
                    }
                }
                if (e2.moveNext()) {
                    return false;
                }
                return true;
            }
            finally {
                e1.dispose();
                e2.dispose();
            }
        };

        EnumerablePrototype.single = function (predicate) {
            if (predicate) {
                return this.where(predicate).single();
            }
            var enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    var current = enumerator.getCurrent();
                    if (enumerator.moveNext()) {
                        throw new Error(invalidOperation);
                    }
                    return current;
                }
            } finally {
                enumerator.dispose();
            }
            throw new Error(seqNoElements);
        };

        EnumerablePrototype.singleOrDefault = function (predicate) {
            if (predicate) {
                return this.where(predicate).single();
            }
            var enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    var current = enumerator.getCurrent();
                    if (enumerator.moveNext()) {
                        throw new Error(invalidOperation);
                    }
                    return current;
                }
            } finally {
                enumerator.dispose();
            }
            return null;
        };        

        EnumerablePrototype.skip = function (count) {
            var parent = this;
            return new Enumerable(function () {
                var current, skipped = false, enumerator;
                return enumeratorCreate(
                    function () {
                        enumerator || (enumerator = parent.getEnumerator());
                        if (!skipped) {
                            for (var i = 0; i < count; i++) {
                                if (!enumerator.moveNext()) {
                                    return false;
                                }
                            }
                            skipped = true;
                        }
                        if (!enumerator.moveNext()) {
                            return false;
                        }
                        current = enumerator.getCurrent();
                        return true;
                    },
                    function () { return current; },
                    function () { enumerator.dispose(); }
                );
            });
        };

        EnumerablePrototype.skipWhile = function (selector) {
            var parent = this;
            return new Enumerable(function () {
                var current, skipped = false, enumerator;
                return enumeratorCreate(
                    function () {
                        enumerator || (enumerator = parent.getEnumerator());
                        if (!skipped) {
                            while (true) {
                                if (!enumerator.moveNext()) {
                                    return false;
                                }
                                if (!selector(enumerator.getCurrent())) {
                                    current = enumerator.getCurrent();
                                    return true;
                                }
                            }
                            skipped = true;
                        }
                        if (!enumerator.moveNext()) {
                            return false;
                        }
                        current = enumerator.getCurrent();
                        return true;
                    },
                    function () { return current;  },
                    function () { enumerator.dispose(); }
                );
            });
        };

        EnumerablePrototype.sum = function(selector) {
            if(selector) {
                return this.select(selector).sum();
            }
            var s = 0, enumerator = this.getEnumerator();
            try {
                while (enumerator.moveNext()) {
                    s += enumerator.getCurrent();
                }
            } finally {
                enumerator.dispose();
            }
            return s;
        };        

        EnumerablePrototype.take = function (count) {
            var parent = this;
            return new Enumerable(function () {
                var current, enumerator, myCount = count;
                return enumeratorCreate(
                    function () {
                        enumerator || (enumerator = parent.getEnumerator());
                        if (myCount === 0) {
                            return false;
                        }
                        if (!enumerator.moveNext()) {
                            myCount = 0;
                            return false;
                        }
                        myCount--;
                        current = enumerator.getCurrent();
                        return true;
                    },
                    function () { return current; },
                    function () { enumerator.dispose(); }
                );
            });
        };

        EnumerablePrototype.takeWhile = function (selector) {
            var parent = this;
            return new Enumerable(function () {
                var current, index = 0, enumerator;
                return enumeratorCreate(
                    function () {
                        enumerator || (enumerator = parent.getEnumerator());
                        if (!enumerator.moveNext()){
                            return false;
                        }
                        current = enumerator.getCurrent();
                        if (!selector(current, index++)){
                            return false;
                        }
                        return true;
                    },
                    function () { return current; },
                    function () { enumerator.dispose(); }
                );
            });
        };        

        EnumerablePrototype.toArray = function () {
            var results = [],
                e = this.getEnumerator();
            try {
                while (e.moveNext()) {
                    results.push(e.getCurrent());
                }
                return results;
            } finally {
                e.dispose();
            }
        };

        EnumerablePrototype.where = function (selector) {
            var parent = this;
            return new Enumerable(function () {
                var current, index = 0, enumerator;
                return enumeratorCreate(
                    function () {
                        enumerator || (enumerator = parent.getEnumerator());
                        while (true) {
                            if (!enumerator.moveNext()) {
                                return false;
                            }
                            current = enumerator.getCurrent();
                            if (selector(current, index++)) {
                                return true;
                            }
                        }
                    },
                    function () { return current; },
                    function () { enumerator.dispose(); }
                );
            });
        };

        EnumerablePrototype.union = function(second, comparer) {
            comparer || (comparer = defaultEqualityComparer);
            var parent = this;
            return enumerableCreate(function () {
                var current, enumerator, map = [], firstDone = false, secondDone = false;
                return enumeratorCreate(
                    function () {
                        while (true) {
                            if (!enumerator) {
                                if (secondDone) {
                                    return false;
                                }
                                if (!firstDone) {
                                    enumerator = parent.getEnumerator();
                                    firstDone = true;
                                } else {
                                    enumerator = second.getEnumerator();
                                    secondDone = true;
                                }
                            }
                            if (enumerator.moveNext()) {
                                current = enumerator.getCurrent();
                                if (arrayIndexOf.call(map, current, comparer) === -1) {
                                    map.push(current);
                                    return true;
                                }
                            } else {
                                enumerator.dispose();
                                enumerator = null;
                            }
                        }
                    },
                    function () { return current; },
                    function () {
                        if (enumerator) {
                            enumerator.dispose();
                        }
                    }
                );
            });
        };          

        EnumerablePrototype.zip = function (right, selector) {
            var parent = this;
            return new Enumerable(function () {
                var e1, e2, current;
                return enumeratorCreate(
                    function () {
                        if (!e1 && !e2) {
                            e1 = parent.getEnumerator();
                            e2 = right.getEnumerator();
                        }

                        if (e1.moveNext() && e2.moveNext()) {
                            current = selector(e1.getCurrent(), e2.getCurrent());
                            return true;
                        }
                        return false;
                    },
                    function () {
                        return current;
                    },
                    function () {
                        e1.dispose();
                        e2.dispose();
                    }
                );
            });
        };

        return Enumerable;
    }());

    var enumerableConcat = Enumerable.concat = function () {
        return enumerableFromArray(arguments).selectMany(identity);
    };

    var enumerableCreate = Enumerable.create = function (getEnumerator) {
        return new Enumerable(getEnumerator);
    };

    var enumerableEmpty = Enumerable.empty = function () {
        return new Enumerable(function () {
            return enumeratorCreate(
                function () { return false; },
                function () { throw new Error(seqNoElements); }
            );
        });
    };

    var enumerableFromArray = Enumerable.fromArray = function (array) {
        return new Enumerable(function () {
            var index = 0, value;
            return enumeratorCreate(
                function () {
                    if (index < array.length) {
                        value = array[index++];
                        return true;
                    }
                    return false;
                },
                function () {
                    return value;
                }
            );
        });
    };

    var enumerableReturn = Enumerable.returnValue = function (value) {
        return new Enumerable(function () {
            var done = false;
            return enumeratorCreate(
                function () {
                    if (done) {
                        return false;
                    }
                    done = true;
                    return true;
                },
                function () {
                    return value;
                }
            );
        });
    };  

    var enumerableRange = Enumerable.range = function (start, count) {
        return new Enumerable(function () {
            var current = start - 1, end = start + count - 1;
            return enumeratorCreate(
                function () {
                    if (current < end) {
                        current++;
                        return true;
                    } else {
                        return false;
                    }
                },
                function () { return current; }
            );
        });
    };  

    var enumerableRepeat = Enumerable.repeat = function (value, count) {
        return new Enumerable(function () {
            var myCount = count;
            if (myCount === undefined) {
                myCount = -1;
            }
            return enumeratorCreate(
                function () {
                    if (myCount !== 0) {
                        myCount--;
                        return true;
                    } else {
                        return false;
                    }
                },
                function () { return value; }
            );
        });
    };          

    function swap (arr, idx1, idx2) {
        var temp = arr[idx1];
        arr[idx1] = arr[idx2];
        arr[idx2] = temp;
    }

    function quickSort(array, start, end) {
        if (start === undefined && end === undefined) {
            start = 0;
            end = array.length - 1;
        }
        var i = start, k = end;
        if (end - start >= 1) {
            var pivot = array[start];
            while (k > i) {
                while (this.compareKeys(array[i], pivot) <= 0 && i <= end && k > i) {
                    i++;
                }
                while (this.compareKeys(array[k], pivot) > 0 && k >= start && k >= i) {
                    k--;
                }
                if (k > i) {
                    swap(array, i, k);
                }
            }
            swap(array, start, k);
            quickSort.call(this, array, start, k - 1);
            quickSort.call(this, array, k + 1, end);
        }
    }  

    function EnumerableSorter (keySelector, comparer, descending, next) {
        this.keySelector = keySelector;
        this.comparer = comparer;
        this.descending = descending;
        this.next = next;
    }

    EnumerableSorter.prototype = {
        computeKeys: function (elements, count) {
            this.keys = new Array(count);
            for (var i = 0; i < count; i++) {
                this.keys[i] = this.keySelector(elements[i]);
            }
            if (this.next) {
                this.next.computeKeys(elements, count);
            }
        },
        compareKeys: function (idx1, idx2) {
            var n = this.comparer(this.keys[idx1], this.keys[idx2]);
            if (n === 0) { 
                return !this.next ? idx1 - idx2 : this.next.compareKeys(idx1, idx2);
            }
            return this.descending ? -n : n;
        },
        sort: function (elements, count) {
            this.computeKeys(elements, count);
            var map = new Array(count);
            for (var i = 0; i < count; i++) {
                map[i] = i;
            }
            quickSort.call(this, map, 0, count - 1);
            return map;
        }
    };

    var OrderedEnumerable = (function () {
        inherits(OrderedEnumerable, Enumerable);
        function OrderedEnumerable (source, keySelector, comparer, descending) {
            this.source = source;
            this.keySelector = keySelector || identity;
            this.comparer = comparer || defaultComparer;
            this.descending = descending;
        }

        var OrderedEnumerablePrototype = OrderedEnumerable.prototype;
        OrderedEnumerablePrototype.getEnumerableSorter = function (next) {
            var next1 = new EnumerableSorter(this.keySelector, this.comparer, this.descending, next);
            if (this.parent) {
                next1 = this.parent.getEnumerableSorter(next1);
            }
            return next1;
        };

        OrderedEnumerablePrototype.createOrderedEnumerable = function (keySelector, comparer, descending) {
            var e = new OrderedEnumerable(this.source, keySelector, comparer, descending);
            e.parent = this;
            return e;
        };

        OrderedEnumerablePrototype.getEnumerator = function () {
            var buffer = this.source.toArray(),
                length = buffer.length,
                sorter = this.getEnumerableSorter(),
                map = sorter.sort(buffer, length),
                index = 0,
                current;

            return enumeratorCreate(function () {
                if (index < length) {
                    current = buffer[map[index++]];
                    return true;
                }
                return false;
            }, function () {
                return current;
            });
        };

        OrderedEnumerablePrototype.thenBy = function (keySelector, comparer) {
            return new OrderedEnumerable(this, keySelector, comparer, false);
        };

        OrderedEnumerablePrototype.thenByDescending = function (keySelector, comparer) {
            return new OrderedEnumerable(this, keySelector, comparer, true);
        };

        return OrderedEnumerable;
    }());

    // Check for AMD
    if (typeof define == 'function' && typeof define.amd == 'object' && define.amd) {
        window.L2O = root;
        return define(function () {
            return root;
        });
    } else if (freeExports) {
        if (typeof module == 'object' && module && module.exports == freeExports) {
            module.exports = root;
        } else {
            freeExports = root;
        }
    } else {
        window.L2O = root;
    }

}(this));



