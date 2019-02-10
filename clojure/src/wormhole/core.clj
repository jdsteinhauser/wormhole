(ns wormhole.core)

(defn reduce-while
  "f should be a function of 2 arguments. "
  [f init coll]
  (loop [acc init
         s (seq coll)]
    (if 
     (empty? s)
      acc
      (let [[halt? x] (f (first s) acc)]
        (if halt? 
          x
          (recur x (rest s)))))))

(defn min-by
  [f coll]
  (first (sort-by f coll)))

(defn max-by
  [f coll]
  (first (reverse (sort-by f coll))))