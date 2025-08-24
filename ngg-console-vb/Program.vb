Imports System

Module Program
    Sub Main(args As String())
        Dim lowerBound As Integer
        Dim upperBound As Integer

        If args.Length() <> 2 OrElse Not Integer.TryParse(args(0), lowerBound) OrElse Not Integer.TryParse(args(1), upperBound) _
            OrElse Not lowerBound < upperBound Then
            PrintHelpMessageAndExit()
        End If

        If upperBound = Integer.MaxValue Then
            Console.WriteLine("Upper bound cannot be Integer.MaxValue.")
            Environment.Exit(1)
        End If

        Dim rnd As New Random()
        Dim trialCounter As Integer = 0

        Console.WriteLine("Game started")
        Console.WriteLine("Computer will pick a random number between " & lowerBound & "-" & upperBound)
        Dim target = rnd.Next(lowerBound, upperBound + 1)
        Do
            Console.WriteLine()
            Console.Write("Pick a number (or type 'quit'): ")

            Dim input As String = Console.ReadLine()
            If input Is Nothing Then Exit Do
            If input.Trim().ToLower() = "quit" Then Exit Do

            Dim guess As Integer

            If Integer.TryParse(input, guess) Then
                trialCounter += 1
                If target = guess Then
                    Console.WriteLine($"You guessed correctly in {trialCounter} time(s)!")
                    Exit Do
                ElseIf guess < target Then
                    Console.WriteLine("Too low. Try again.")
                Else
                    Console.WriteLine("Too high. Try again.")
                End If
            Else
                Console.WriteLine("Invalid input! Enter an integer.")
            End If
        Loop
        Console.WriteLine("Game ended")
    End Sub

    Private Sub PrintHelpMessageAndExit()
        Console.WriteLine("Usage: NumberGuessGame <lowerBound> <upperBound>")
        Console.WriteLine("Both arguments must be integers, and lowerBound < upperBound.")
        Console.WriteLine("Example: NumberGuessGame 1 100")
        Environment.Exit(1)
    End Sub
End Module
