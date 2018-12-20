defmodule Wormhole do
  @doc ~S"""
  Returns a map with the number of occurrences of each item in an Enumerable.

  ## Examples

    iex> Wormhole.freqs(1, 1, 1, 2, 2, 4)
    %{1 => 3, 2 => 2, 4 => 1}

    iex> Wormhole.freqs(1..6) |> Map.values()
    [1, 1, 1, 1, 1, 1]

  """
  def freqs(enum), do: Map.new(Enum.group_by(enum, & &1), fn {k, xs} -> {k, Enum.count(xs)} end)

  @doc ~S"""
  Returns a function that will evaluate all passed functions in the list `fs`
  and return those values in input function order.

  ## Example

    iex> Wormhole.juxt([&Kernel.+/2, &Kernel.*/2]).([3,5])
    [8, 15]
  """
  def juxt(fs) do
    (fn x -> Enum.map(fs, fn f -> apply(f, x) end) end)
  end

  @doc ~S"""
  Increments an integer by 1.

  ## Example

    iex> Wormhole.inc(3)
    4
  """
  def inc(x), do: x + 1  

  @doc ~S"""
  Decrements an integer by 1.

  ## Example

    iex> Wormhole.dec(3)
    2
  """
  def dec(x), do: x - 1  
end
