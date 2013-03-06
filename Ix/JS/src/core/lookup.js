    var Lookup = (function () {
        inherits(Lookup, Enumerable);
        function Lookup(comparer) {
            this.comparer = comparer || defaultEqualityComparer;
            this.groupings = [];
            this.length = 0;
            this.lastGrouping = null;
        }

        var LookupPrototype = Lookup.prototype;

        Lookup.create = function (source, keySelector, elementSelector, comparer) {
            var lookup = new Lookup(comparer);
            source.forEach(function (item) {
                lookup.getGrouping(keySelector(item), true).push(elementSelector(item));
            });
            return lookup;
        };

        Lookup.createJoinFor = function (source, keySelector, elementSelector, comparer) {
            var lookup = new Lookup(comparer);
            source.forEach(function (item) {
                var key = keySelector(item);
                if (key != null) {
                    lookup.GetGrouping(key, true).push(item);
                }
            });
            return lookup;
        };
        
        LookupPrototype.get = function(key) {
            return this.getGrouping(key, false) || enumerableEmpty;
        };

        LookupPrototype.contains = function (key) {
            return this.getGrouping(key, false) != null;
        };

        LookupPrototype.getEnumerator = function () {
            var g, current, self = this, isFirst = true;
            return enumeratorCreate(
                function () {
                    if (isFirst) {
                        g = self.lastGrouping;
                        if (!g) {
                            return false;
                        }
                        isFirst = false;
                    } else {
                        if (g === self.lastGrouping) { return false; }
                    }

                    g = g.next;
                    return true;
                },
                function () { return g; }
            );
        };

        return Lookup;

    }());