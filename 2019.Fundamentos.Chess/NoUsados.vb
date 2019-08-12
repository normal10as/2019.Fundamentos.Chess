Module NoUsados
    Function IngrezarPieza() As Piezas
        Dim pieza As Char
        Do
            Console.Write("Ingrese pieza: ")
            pieza = Console.ReadLine()
        Loop Until ValidarPieza(pieza)
        Return getPieza(pieza)
    End Function
    Function ValidarPieza(pieza As Char) As Boolean
        Select Case pieza
            Case "p", "r", "d", "t", "a", "c"
                Return True
            Case Else
                Return False
        End Select
    End Function
    Function getPieza(pieza As Char) As Piezas
        Select Case pieza
            Case "p"
                Return Piezas.Peón
            Case "r"
                Return Piezas.Rey
            Case "d"
                Return Piezas.Dama
            Case "t"
                Return Piezas.Torre
            Case "a"
                Return Piezas.Alfil
            Case "c"
                Return Piezas.Caballo
            Case Else
                Return Piezas._nula_
        End Select
    End Function
    Function EstaPiezaEnCasilla(tablero(,) As Piezas, pieza As Piezas, columna As Char, fila As SByte) As Boolean
        Return tablero(getIndiceDeColumna(columna), fila) = pieza
    End Function
End Module
