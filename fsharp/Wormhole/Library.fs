namespace Wormhole

    module Utility =

        let inline inc x = x + 1

        let inline dec x = x - 1

        let juxt fs x =
            Array.map (fun f -> f x) fs

        let juxt2 fs x y =
            Array.map (fun f -> f x y) fs

        let juxt3 fs x y z =
            Array.map (fun f -> f x y z) fs

    module Sequences = 
        let freqs xs =
            xs
            |> Seq.groupBy id
            |> Seq.map (fun k v -> k, Seq.length v)

        let zipall xs =
            let rec impl xs acc =
                if Seq.exists (fun x -> Seq.length x = 0) xs
                then List.rev acc
                else impl (Seq.map Seq.tail xs) ((Seq.map Seq.head xs) :: acc)

            impl xs []


        let chunk step size keepLeftover xs =
            let rec impl xs acc =
                if Seq.length xs < size
                then List.rev acc
                else impl (Seq.drop step xs) ((Seq.take step xs) :: acc)
            xs []