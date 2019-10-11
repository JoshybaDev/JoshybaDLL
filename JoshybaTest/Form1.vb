Public Class Form1

    Private Sub cmd_prueba_Click(sender As Object, e As EventArgs) Handles cmd_prueba.Click
        MsgBox(Joshyba.Numeros_a_Letras.Convertir_Numero("859", "mone"))
        'MsgBox(P.Generar_Tamanio("Joshyba es el mejor de los mejores ", 50))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim valores As Integer() = {4, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5}
        Dim res() As Integer
        Dim ode = New Joshyba.Ordenamiento_QUICKSORT()
        res = ode.ordernar(valores)
        For i = 0 To res.Length - 1
            MsgBox(res(i))
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(Joshyba.Numeros_a_Letras.Convertir_Numero(txt_prueba.Text, "moneda"))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim folio_ficha As String = ""
        'If Joshyba.Formularios_Full.InputBox("folio para esta ficha - Solo Numeros", "folio No:", folio_ficha, Joshyba.Formularios_Full.TipoTextBox.PuroNumero) = Windows.Forms.DialogResult.OK Then
        '    MsgBox(folio_ficha)
        'End If
        If Joshyba.Formularios_Full.InputBox("folio para esta ficha - Solo Numeros", "folio No:", folio_ficha, Joshyba.Formularios_Full.TipoTextBox.PuroTexto) = Windows.Forms.DialogResult.OK Then
            MsgBox(folio_ficha)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If BarraProgresoCircular1.Value = 100 Then
            BarraProgresoCircular1.Value = 0
        Else
            For i As Integer = 0 To 100
                BarraProgresoCircular1.Value = i
                Threading.Thread.Sleep(100)
            Next
        End If
    End Sub

    Private Sub cmdComprimir_Click(sender As Object, e As EventArgs) Handles cmdComprimir.Click
        Joshyba.Comprimir7zip.Comprimir("RecibosE", Joshyba.Comprimir7zip.xTipo._7Z, """C:\Users\Joshyba\Documents\Visual Studio 2015\Projects\Joshyba\JoshybaTest\bin\Debug\RecibosE""")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Archivos((1 * 2) - 1) As String
        Archivos(0) = "C:\Users\Joshyba\Documents\Visual Studio 2015\Projects\Facilita\Facilita\bin\Debug\Recibos\X\10.pdf "
        Archivos(1) = "C:\Users\Joshyba\Documents\Visual Studio 2015\Projects\Facilita\Facilita\bin\Debug\Recibos\X\11.pdf "
        Joshyba.Unir_PDF.Uniendo(Archivos, Application.StartupPath & "\full_Reporte_Evidencia_Solicutudes_Ministracion_01_06_2018.pdf")

    End Sub
End Class
