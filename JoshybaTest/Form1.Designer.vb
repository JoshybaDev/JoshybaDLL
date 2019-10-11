<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmd_prueba = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.MarqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdComprimir = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBoxNumeric1 = New Joshyba.Controles.TextBoxNumeric()
        Me.TextFull1 = New Joshyba.Controles.TextFull()
        Me.IconComboBox1 = New Joshyba.Controles.IconComboBox()
        Me.GlassButton1 = New Joshyba.Controles.GlassButton()
        Me.BarraProgresoCircular1 = New Joshyba.Controles.BarraProgresoCircular()
        Me.CtrlComboBoxMultiColumn2 = New Joshyba.CtrlComboBoxMultiColumn()
        Me.TextBoxFullBordes1 = New Joshyba.Controles.TextBoxFullBordes()
        Me.txt_prueba = New Joshyba.Controles.TextFull()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_prueba
        '
        Me.cmd_prueba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_prueba.Location = New System.Drawing.Point(423, 16)
        Me.cmd_prueba.Margin = New System.Windows.Forms.Padding(4)
        Me.cmd_prueba.Name = "cmd_prueba"
        Me.cmd_prueba.Size = New System.Drawing.Size(208, 32)
        Me.cmd_prueba.TabIndex = 0
        Me.cmd_prueba.Text = "covierte a moneda"
        Me.cmd_prueba.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(423, 56)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 66)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Ordenamiento_QUICKSORT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(423, 130)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(208, 66)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "lo de lo convierte a letras"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarControl1.Location = New System.Drawing.Point(413, 377)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(212, 29)
        Me.ProgressBarControl1.TabIndex = 8
        '
        'MarqueeProgressBarControl1
        '
        Me.MarqueeProgressBarControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MarqueeProgressBarControl1.EditValue = 0
        Me.MarqueeProgressBarControl1.Location = New System.Drawing.Point(410, 420)
        Me.MarqueeProgressBarControl1.Name = "MarqueeProgressBarControl1"
        Me.MarqueeProgressBarControl1.Size = New System.Drawing.Size(214, 19)
        Me.MarqueeProgressBarControl1.TabIndex = 9
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(423, 203)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(208, 65)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Inputbox solo numeros"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(425, 282)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(204, 41)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Ejecutar Progreso circular"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmdComprimir
        '
        Me.cmdComprimir.Location = New System.Drawing.Point(22, 344)
        Me.cmdComprimir.Name = "cmdComprimir"
        Me.cmdComprimir.Size = New System.Drawing.Size(202, 45)
        Me.cmdComprimir.TabIndex = 16
        Me.cmdComprimir.Text = "Comprimir"
        Me.cmdComprimir.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(23, 394)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(202, 45)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Unir PdF"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBoxNumeric1
        '
        Me.TextBoxNumeric1._Formato_Numero = "{0, 0:C2}"
        Me.TextBoxNumeric1.Location = New System.Drawing.Point(236, 134)
        Me.TextBoxNumeric1.MarcaAguaText = "Ingrese un Dato..."
        Me.TextBoxNumeric1.Name = "TextBoxNumeric1"
        Me.TextBoxNumeric1.Size = New System.Drawing.Size(174, 22)
        Me.TextBoxNumeric1.TabIndex = 21
        Me.TextBoxNumeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextFull1
        '
        Me.TextFull1._Formato_Numero = ""
        Me.TextFull1._Solo_Lectura = False
        Me.TextFull1.Location = New System.Drawing.Point(246, 100)
        Me.TextFull1.MarcaAguaText = "Ingrese un Dato..."
        Me.TextFull1.Name = "TextFull1"
        Me.TextFull1.Size = New System.Drawing.Size(135, 22)
        Me.TextFull1.TabIndex = 20
        '
        'IconComboBox1
        '
        Me.IconComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.IconComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IconComboBox1.FormattingEnabled = True
        Me.IconComboBox1.Location = New System.Drawing.Point(246, 52)
        Me.IconComboBox1.Name = "IconComboBox1"
        Me.IconComboBox1.SelectedItem = Nothing
        Me.IconComboBox1.Size = New System.Drawing.Size(146, 23)
        Me.IconComboBox1.TabIndex = 19
        Me.IconComboBox1.ToolTipText = ""
        '
        'GlassButton1
        '
        Me.GlassButton1.BackColor = System.Drawing.Color.Gray
        Me.GlassButton1.GlowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GlassButton1.Location = New System.Drawing.Point(22, 463)
        Me.GlassButton1.Name = "GlassButton1"
        Me.GlassButton1.Size = New System.Drawing.Size(238, 48)
        Me.GlassButton1.TabIndex = 18
        Me.GlassButton1.Text = "GlassButton1"
        '
        'BarraProgresoCircular1
        '
        Me.BarraProgresoCircular1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BarraProgresoCircular1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BarraProgresoCircular1.ColorFondoCentral = System.Drawing.Color.Linen
        Me.BarraProgresoCircular1.ColorFondoProgreso = System.Drawing.Color.LightCoral
        Me.BarraProgresoCircular1.ColorProgreso = System.Drawing.Color.DarkRed
        Me.BarraProgresoCircular1.ColorTexto = System.Drawing.Color.DarkRed
        Me.BarraProgresoCircular1.Location = New System.Drawing.Point(14, 45)
        Me.BarraProgresoCircular1.Name = "BarraProgresoCircular1"
        Me.BarraProgresoCircular1.Size = New System.Drawing.Size(211, 263)
        Me.BarraProgresoCircular1.TabIndex = 15
        Me.BarraProgresoCircular1.Value = 0
        '
        'CtrlComboBoxMultiColumn2
        '
        Me.CtrlComboBoxMultiColumn2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlComboBoxMultiColumn2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.CtrlComboBoxMultiColumn2.FormattingEnabled = True
        Me.CtrlComboBoxMultiColumn2.Location = New System.Drawing.Point(413, 340)
        Me.CtrlComboBoxMultiColumn2.Name = "CtrlComboBoxMultiColumn2"
        Me.CtrlComboBoxMultiColumn2.Size = New System.Drawing.Size(216, 23)
        Me.CtrlComboBoxMultiColumn2.TabIndex = 14
        '
        'TextBoxFullBordes1
        '
        Me.TextBoxFullBordes1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFullBordes1.BackColor = System.Drawing.Color.White
        Me.TextBoxFullBordes1.BackGroudColor = System.Drawing.Color.White
        Me.TextBoxFullBordes1.BorderColor = System.Drawing.Color.Aqua
        Me.TextBoxFullBordes1.BorderSize = 1
        Me.TextBoxFullBordes1.Location = New System.Drawing.Point(411, 480)
        Me.TextBoxFullBordes1.Multiline = False
        Me.TextBoxFullBordes1.Name = "TextBoxFullBordes1"
        Me.TextBoxFullBordes1.PaddingLeft = 2
        Me.TextBoxFullBordes1.PaddingTop = 2
        Me.TextBoxFullBordes1.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBoxFullBordes1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBoxFullBordes1.Size = New System.Drawing.Size(214, 25)
        Me.TextBoxFullBordes1.TabIndex = 10
        Me.TextBoxFullBordes1.Text2 = "TextBox"
        Me.TextBoxFullBordes1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TextBoxFullBordes1.WordWrap = True
        '
        'txt_prueba
        '
        Me.txt_prueba._Formato_Numero = ""
        Me.txt_prueba._Solo_Lectura = False
        Me.txt_prueba.Location = New System.Drawing.Point(14, 16)
        Me.txt_prueba.MarcaAguaText = "Escribe un numero para convertirlo a letras"
        Me.txt_prueba.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_prueba.Name = "txt_prueba"
        Me.txt_prueba.Size = New System.Drawing.Size(286, 22)
        Me.txt_prueba.TabIndex = 5
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(410, 449)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(218, 25)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 22
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 517)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBoxNumeric1)
        Me.Controls.Add(Me.TextFull1)
        Me.Controls.Add(Me.IconComboBox1)
        Me.Controls.Add(Me.GlassButton1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.cmdComprimir)
        Me.Controls.Add(Me.BarraProgresoCircular1)
        Me.Controls.Add(Me.CtrlComboBoxMultiColumn2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBoxFullBordes1)
        Me.Controls.Add(Me.MarqueeProgressBarControl1)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_prueba)
        Me.Controls.Add(Me.cmd_prueba)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "0"
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_prueba As System.Windows.Forms.Button
    Friend WithEvents CtrlComboBoxMultiColumn1 As Joshyba.CtrlComboBoxMultiColumn
    Friend WithEvents Barra_Progreso_31 As Joshyba.Barra_Progreso_3
    Friend WithEvents Barra_Progreso_32 As Joshyba.Barra_Progreso_3
    Friend WithEvents txt_prueba As Joshyba.Controles.TextFull
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents MarqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents TextBoxFullBordes1 As Joshyba.Controles.TextBoxFullBordes
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents CtrlComboBoxMultiColumn2 As Joshyba.CtrlComboBoxMultiColumn
    Friend WithEvents BarraProgresoCircular1 As Joshyba.Controles.BarraProgresoCircular
    Friend WithEvents cmdComprimir As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents GlassButton1 As Joshyba.Controles.GlassButton
    Friend WithEvents IconComboBox1 As Joshyba.Controles.IconComboBox
    Friend WithEvents TextFull1 As Joshyba.Controles.TextFull
    Friend WithEvents TextBoxNumeric1 As Joshyba.Controles.TextBoxNumeric
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
