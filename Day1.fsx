open System.IO

let linesLargerThanPrev (filename: string) =
    let lines = File.ReadAllLines(filename)
    let result = ref 0
    let prevLine = ref lines[0]

    for line in lines[1..] do
        if int(line) > int(prevLine.Value) then
            printfn $"line: {line} is more than prev: {prevLine}"
            result.Value <- result.Value + 1
        prevLine.Value <- line

    result.Value

let windowsLargerThanPrev (filename: string) =
    let lines = File.ReadAllLines(filename)
    let result = ref 0
    let prevWindow = ref [|lines[0]; lines[1]; lines[2]|]
    let windows = lines[3..] |> Seq.windowed(3)

    for window in windows do
        let windowSum = int(window[0]) + int(window[1]) + int(window[2])
        let prevWindowSum = int(prevWindow.Value[0]) + int(prevWindow.Value[1]) + int(prevWindow.Value[2])
        if windowSum > prevWindowSum then
            printfn $"windowSum: {windowSum} is more than prev: {prevWindowSum}"
            result.Value <- result.Value + 1
        prevWindow.Value <- window

    result.Value
