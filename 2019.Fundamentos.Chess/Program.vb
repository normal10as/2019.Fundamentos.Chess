Imports System.Math
Module Program
    Sub Main(args As String())
        Dim tablero(,) As Piezas = getTablero()
        Dim pieza As Piezas
        'Dim columna As Char
        Dim columnaOrigen, filaOrigen, columaDestino, filaDestino As SByte
        Do
            MostrarTablero(tablero)
            'pieza = IngrezarPieza()
            'Console.WriteLine(IngrezarPieza().ToString)
            Console.WriteLine("Origen")
            columnaOrigen = IngresarColumna()
            'Console.WriteLine(getColumnaIndice(IngresarColumna()))
            filaOrigen = IngresarFila()
            'Console.WriteLine(IngresarFila())
            pieza = getPiezaEnCasilla(tablero, columnaOrigen, filaOrigen)
            Console.WriteLine(pieza.ToString)
            If isPieza(pieza) Then
                Console.WriteLine("Destino")
                columaDestino = IngresarColumna()
                filaDestino = IngresarFila()
                If getPiezaEnCasilla(tablero, columaDestino, filaDestino) = Piezas.__ Then
                    If validarMovimiento(pieza, columnaOrigen, filaOrigen, columaDestino, filaDestino) Then
                        moverPieza(tablero, columnaOrigen, filaOrigen, columaDestino, filaDestino)
                        Console.WriteLine("Pieza movida")
                    Else
                        Console.WriteLine("Movimiento inv�lido")
                    End If
                Else
                    Console.WriteLine("Ya hay pieza en esa posici�n")
                End If
            Else
                Console.WriteLine("No hay pieza en esa posici�n")
            End If
            Console.ReadKey()
            'Loop Until EstaPiezaEnCasilla(tablero, pieza, columnaOrigen, filaOrigen)
        Loop While True
    End Sub
    Private Function isPieza(pieza As Piezas) As Boolean
        Return pieza <> Piezas.__
    End Function
    Function IngresarColumna() As SByte
        Dim columna As Char
        Do
            Console.Write("Ingrese columna: ")
            columna = Console.ReadLine()
        Loop Until validarColumna(columna)
        Return getIndiceDeColumna(columna)
    End Function
    Function getIndiceDeColumna(columna As Char) As SByte
        Return AscW(columna) - 97
    End Function
    Function validarColumna(columna As Char) As Boolean
        Return columna >= "a" And columna <= "h"
    End Function
    Function IngresarFila() As SByte
        Dim fila As SByte
        Do
            Console.Write("Ingrese fila: ")
            fila = Console.ReadLine()
        Loop Until validarFila(fila)
        Return fila - 1
    End Function
    Function validarFila(fila As SByte) As Boolean
        Return fila >= 1 And fila <= 8
    End Function
    Function getPiezaEnCasilla(tablero(,) As Piezas, columna As SByte, fila As SByte) As Piezas
        Return tablero(columna, fila)
    End Function
    Function validarMovimiento(pieza As Piezas, columnaOrigen As SByte, filaOrigen As SByte, columnaDestino As SByte, filaDestino As SByte) As Boolean
        Select Case pieza
            Case Piezas.Alfil
                If Abs(columnaOrigen - columnaDestino) = Abs(filaOrigen - filaDestino) Then
                    Return True
                End If
            Case Piezas.Dama
                Return validarMovimiento(Piezas.Alfil, columnaOrigen, filaOrigen, columnaDestino, filaDestino) Or validarMovimiento(Piezas.Torre, columnaOrigen, filaOrigen, columnaDestino, filaDestino)
            Case Piezas.Caballo
                If (Abs(columnaOrigen - columnaDestino) = 1 And Abs(filaOrigen - filaDestino) = 2) Or (Abs(columnaOrigen - columnaDestino) = 2 And Abs(filaOrigen - filaDestino) = 1) Then
                    Return True
                End If
            Case Piezas.Pe�n
                If columnaOrigen = columnaDestino And filaOrigen + 1 = filaDestino Then
                    Return True
                End If
            Case Piezas.Rey
                If Abs(columnaOrigen - columnaDestino) = 1 Or Abs(filaOrigen - filaDestino) = 1 Then
                    Return True
                End If
            Case Piezas.Torre
                If (columnaOrigen = columnaDestino And filaOrigen <> filaDestino) Or (columnaOrigen <> columnaDestino And filaOrigen = filaDestino) Then
                    Return True
                End If
        End Select
        Return False
    End Function
    Sub moverPieza(tablero(,) As Piezas, columnaOrigen As SByte, filaOrigen As SByte, columnaDestino As SByte, filaDestino As SByte)
        tablero(columnaDestino, filaDestino) = tablero(columnaOrigen, filaOrigen)
        tablero(columnaOrigen, filaOrigen) = Piezas.__
    End Sub
    Sub MostrarTablero(tablero(,) As Piezas)
        Console.Clear()
        For fila = 7 To 0 Step -1
            Console.Write(fila + 1 & vbTab)
            For columna = 0 To 7 Step 1
                Console.Write(tablero(columna, fila).ToString & vbTab)
            Next
            Console.WriteLine(vbCrLf)
        Next
        For x = 97 To 104
            Console.Write(vbTab & ChrW(x))
        Next
        Console.WriteLine()
    End Sub
End Module