# Wormhole

You ever think, "Hey I wish this langugage had the capability of some other language I like?" Enter Wormhole.

## Usage

  1. Add wormhole to your list of dependencies in mix.exs:
```elixir
def deps do
  [{:wormhole, "~> 0.0.1"}]
end
```

## Functions

### Implemented in the language
- `map` - `Enum.map` and `Stream.map`
- `filter`
- `reduce`
- `reduce_while`
- `chunk`
- `chunk_by`
- `min_by`
- `max_by`
- `group_by`

### Implemented in Wormhole
- `juxt` - `Wormhole.juxt`
- `frequencies` - `Wormhole.freqs`