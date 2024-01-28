Public Class MainForm

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' Variables para almacenar los datos ingresados por el usuario
        Dim nombre As String
        Dim apellido As String
        Dim edad As Integer
        Dim altura As Decimal

        ' Uso de Try-Catch para manejar posibles errores al intentar convertir los datos ingresados por el usuario
        Try
            ' Obtener datos del usuario - Casting Implicito
            nombre = txtNombre.Text
            apellido = txtApellido.Text
            edad = Integer.Parse(txtEdad.Text)
            altura = Decimal.Parse(txtAltura.Text)

            ' Operaciones con los datos
            ' Concatenacion
            Dim nombreCompleto As String = nombre & " " & apellido
            ' Casting Explicito
            Dim añoNacimiento As Integer = Date.Today.Year - edad
            Dim alturaEnCm As Decimal = altura * 100

            ' Mostrar resultados en el cuadro de texto de salida - Concatenacion
            rtbResultado.Text = "Nombre Completo: " & nombreCompleto & " (Tipo: " & nombreCompleto.GetType().ToString() & ")" & vbCrLf &
                                "Año de Nacimiento Aproximado: " & añoNacimiento & " (Tipo: " & añoNacimiento.GetType().ToString() & ")" & vbCrLf &
                                "Altura en Centímetros: " & alturaEnCm & " (Tipo: " & alturaEnCm.GetType().ToString() & ")"

        Catch ex As Exception
            ' Mostrar mensaje de error si los datos ingresados no son válidos
            MessageBox.Show("Error: Los datos ingresados no son válidos. Por favor, asegúrese de ingresar valores numéricos para la edad y la altura.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
