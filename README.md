# Wormhole

You ever think, "Hey I wish this langugage had the capability of some other language I like?" Enter Wormhole.

## Installation

  1. Add wormhole to your list of dependencies in mix.exs:

        def deps do
          [{:wormhole, "~> 0.0.1"}]
        end

## Future Work
  I'd like to pull functions from other languages in as well. The `frequencies` function from Clojure
  would have been helpful in several Advent of Code puzzles, and so I've ported it to Elixir. I plan
  on delivering a similar library in multiple languages that I use (Clojure, Elixir, OCaml, F#).