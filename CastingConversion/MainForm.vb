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
            Dim nombreCompleto As String = nombre & " " & apellido ' Aqui usamos el proceso de concatenado para poder unir el nombre y apellido en una sola linea
            ' Casting Explicito
            Dim añoNacimiento As Integer = Date.Today.Year - edad ' aqui hacemos el uso de una nueva variable de tipo Int para poder realizar el calculo de la fecha de nacimiento
            Dim alturaEnCm As Decimal = altura * 100 ' Aqui usando una nueva variable decimal, convertimos la altura dada en decimales y la multiplicamos
            'por el entero 100, el sistema se encarga de convertir el 100 a decimal para poder obtener el resultado correcto

            ' Mostrar resultados en el cuadro de texto de salida - Concatenacion
            ' Aqui reunimos todos los datos calculados, para unirlos en una sola cadena y realizar la salida de datos en el RichTExtbox
            rtbResultado.Text = "Nombre Completo: " & nombreCompleto & " (Tipo: " & nombreCompleto.GetType().ToString() & ")" & vbCrLf &
                                "Año de Nacimiento Aproximado: " & añoNacimiento & " (Tipo: " & añoNacimiento.GetType().ToString() & ")" & vbCrLf &
                                "Altura en Centímetros: " & alturaEnCm & " (Tipo: " & alturaEnCm.GetType().ToString() & ")"

        Catch ex As Exception
            ' Mostrar mensaje de error si los datos ingresados no son válidos
            MessageBox.Show("Error: Los datos ingresados no son válidos. Por favor, asegúrese de ingresar valores numéricos para la edad y la altura.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
