Imports System.IO
Imports System.Text.RegularExpressions

Public Class MainForm

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        readData()
        Clear()
    End Sub

    Private Sub readData()
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

            Save()
        Catch ex As Exception
            ' Mostrar mensaje de error si los datos ingresados no son válidos
            MessageBox.Show("Error: Los datos ingresados no son válidos. Por favor, asegúrese de ingresar valores numéricos para la edad y la altura.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Está seguro que desea salir?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra la aplicación
            Application.Exit()
        End If
    End Sub

    ' Funcion para leer el contenido del archivo de texto
    Private Sub ReadTXT()
        ' Limpia y reestablece los elementos 
        Clear()

        EliminaLineaVacia()

        ' Limpiar los DataGridView
        DataGridView1.Rows.Clear()

        ' Lee el archivo de texto y procesa la informacion
        Using sr As New StreamReader("DATA.txt")
            Dim linea As String
            While Not sr.EndOfStream ' Mientras no llegue a la ultima linea, no va a dejar de leer.
                linea = sr.ReadLine()
                ' Dividir la línea en elementos usando la coma como delimitador
                Dim elementos As String() = linea.Split(","c)
                ' Agregamos la info
                DataGridView1.Rows.Add(elementos)
            End While
        End Using
    End Sub

    Private Sub Save()
        If MessageBox.Show("¿Quiere guardar la informacion?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            ' Guardamos el texto concatenado a nuestro archivo de texto.
            File.AppendAllText("DATA.txt", Environment.NewLine + (txtNombre.Text & "," & txtApellido.Text & "," & txtEdad.Text & "," & txtAltura.Text))

            Clear()
            ReadTXT() ' Leemos nuevamente el archivo
            EliminaLineaVacia()
        End If
    End Sub

    ' Funcion para leer nuestro archivo de texto y en caso de que existan lineas en blanco esto los eliminará
    Private Sub EliminaLineaVacia()
        Dim strFile As String = File.ReadAllText("DATA.txt")
        strFile = Regex.Replace(strFile, "^\r|\n\r|\n$", "")
        File.WriteAllText("DATA.txt", strFile)
    End Sub

    ' Funcion para limpiar los datos
    Private Sub Clear()
        txtAltura.Text = ""
        txtApellido.Text = ""
        txtEdad.Text = ""
        txtNombre.Text = ""
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadTXT()
        EliminaLineaVacia()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Clear()
    End Sub
End Class
