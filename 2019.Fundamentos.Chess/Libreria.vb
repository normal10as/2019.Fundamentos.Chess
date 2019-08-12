Module Libreria
    Enum Piezas
        _nula_
        Peón
        Rey
        Dama
        Torre
        Alfil
        Caballo
    End Enum
    Function getTablero() As Piezas(,)
        Dim tablero(7, 7) As Piezas
        tablero(0, 0) = Piezas.Torre
        tablero(2, 2) = Piezas.Caballo
        tablero(2, 1) = Piezas.Alfil
        tablero(3, 4) = Piezas.Dama
        tablero(5, 5) = Piezas.Rey
        tablero(5, 1) = Piezas.Alfil
        tablero(6, 0) = Piezas.Caballo
        tablero(7, 3) = Piezas.Torre
        Return tablero
    End Function
    Sub MostrarTablero(tablero(,) As Piezas)
        Console.Clear()
        Dim fila
        Console.Write(vbCrLf & fila & vbTab)
        Dim columna
        Console.Write(tablero(columna, fila).ToString & vbTab)
        Console.WriteLine()
        For letra = 97 To 97
            Console.Write(vbTab & ChrW(letra))
        Next
        Console.WriteLine()
    End Sub
End Module
