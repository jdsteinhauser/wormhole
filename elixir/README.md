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
- `map` - [`Enum.map`](https://hexdocs.pm/elixir/Enum.html#map/2) and [`Stream.map`](https://hexdocs.pm/elixir/Stream.html#map/2)
- `filter` - [`Enum.filter`](https://hexdocs.pm/elixir/Enum.html#filter/2)
- `reduce` - [`Enum.reduce`](https://hexdocs.pm/elixir/Enum.html#reduce/3)
- `reduce_while` - [`Enum.reduce_while`](https://hexdocs.pm/elixir/Enum.html#reduce_while/3)
- `chunk` - [`Enum.chunk_every`](https://hexdocs.pm/elixir/Enum.html#chunk_every/2) and [`Stream.chunk_every`](https://hexdocs.pm/elixir/Stream.html#chunk_every/2)
- `chunk_by` - [`Enum.chunk_by`](https://hexdocs.pm/elixir/Enum.html#chunk_by/2) and [`Stream.chunk_by`](https://hexdocs.pm/elixir/Stream.html#chunk_by/2)
- `min_by` - [`Enum.min_by`](https://hexdocs.pm/elixir/Enum.html#min_by/3)
- `max_by` - [`Enum.max_by`](https://hexdocs.pm/elixir/Enum.html#max_by/3)
- `group_by` - [`Enum.group_by`](https://hexdocs.pm/elixir/Enum.html#group_by/3)

### Implemented in Wormhole
- `juxt` - `Wormhole.juxt`
- `frequencies` - `Wormhole.freqs`