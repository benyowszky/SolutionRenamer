<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnOpenSolution = New System.Windows.Forms.Button()
        Me.txtCurrentSolutionName = New System.Windows.Forms.TextBox()
        Me.txtNewSolutionName = New System.Windows.Forms.TextBox()
        Me.btnRenameSolution = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnOpenSolution
        '
        Me.btnOpenSolution.Location = New System.Drawing.Point(447, 24)
        Me.btnOpenSolution.Name = "btnOpenSolution"
        Me.btnOpenSolution.Size = New System.Drawing.Size(100, 23)
        Me.btnOpenSolution.TabIndex = 0
        Me.btnOpenSolution.Text = "Open Solution"
        Me.btnOpenSolution.UseVisualStyleBackColor = True
        '
        'txtCurrentSolutionName
        '
        Me.txtCurrentSolutionName.Location = New System.Drawing.Point(133, 26)
        Me.txtCurrentSolutionName.Name = "txtCurrentSolutionName"
        Me.txtCurrentSolutionName.ReadOnly = True
        Me.txtCurrentSolutionName.Size = New System.Drawing.Size(308, 20)
        Me.txtCurrentSolutionName.TabIndex = 1
        '
        'txtNewSolutionName
        '
        Me.txtNewSolutionName.Location = New System.Drawing.Point(133, 52)
        Me.txtNewSolutionName.Name = "txtNewSolutionName"
        Me.txtNewSolutionName.Size = New System.Drawing.Size(308, 20)
        Me.txtNewSolutionName.TabIndex = 2
        '
        'btnRenameSolution
        '
        Me.btnRenameSolution.Location = New System.Drawing.Point(447, 50)
        Me.btnRenameSolution.Name = "btnRenameSolution"
        Me.btnRenameSolution.Size = New System.Drawing.Size(100, 23)
        Me.btnRenameSolution.TabIndex = 3
        Me.btnRenameSolution.Text = "Rename Solution"
        Me.btnRenameSolution.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Old Solution Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "New Solution Name"
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(12, 98)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(921, 492)
        Me.txtLog.TabIndex = 6
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 602)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRenameSolution)
        Me.Controls.Add(Me.txtNewSolutionName)
        Me.Controls.Add(Me.txtCurrentSolutionName)
        Me.Controls.Add(Me.btnOpenSolution)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SolutionRenamer"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOpenSolution As Button
    Friend WithEvents txtCurrentSolutionName As TextBox
    Friend WithEvents txtNewSolutionName As TextBox
    Friend WithEvents btnRenameSolution As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLog As TextBox
End Class
