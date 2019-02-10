(ns wormhole.core-test
  (:require [clojure.test :refer :all]
            [wormhole.core :refer :all]))

(deftest reduce-while-tests
  (testing "Empty Collection"
    (is (= 0
           (reduce-while #(vector false (+ %1 %2)) 0 []))))
  (testing "Nil Collection"
    (is (= 0
           (reduce-while #(vector false (+ %1 %2)) 0 nil))))
  (testing "While Less Than Five"
    (is (= 15
           (reduce-while 
            (fn [x acc] (if (< 5 x) [true acc] [false (+ x acc)]))
            0
            (range 10)))))
  (testing "While Less Than Five Plus Three"
    (is (= 18
           (reduce-while
            (fn [x acc] (if (< 5 x) [true acc] [false (+ x acc)]))
            3
            (range 10))))))

(deftest min-by-tests
  (testing "Sum"
    (is (= [4 0 0]
           (min-by (partial reduce +) [[1 2 3] [4 0 0]])))))

(deftest max-by-tests
  (testing "Sum"
    (is (= [1 2 3]
           (max-by (partial reduce +) [[1 2 3] [4 0 0]])))))