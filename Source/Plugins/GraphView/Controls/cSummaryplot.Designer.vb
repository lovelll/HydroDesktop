﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cSummaryPlot
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.zgSummaryPlot = New ZedGraph.ZedGraphControl
        Me.SuspendLayout()
        '
        'zgSummaryPlot
        '
        Me.zgSummaryPlot.AutoScroll = True
        Me.zgSummaryPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgSummaryPlot.Location = New System.Drawing.Point(0, 0)
        Me.zgSummaryPlot.Name = "zgSummaryPlot"
        Me.zgSummaryPlot.ScrollGrace = 0
        Me.zgSummaryPlot.ScrollMaxX = 0
        Me.zgSummaryPlot.ScrollMaxY = 0
        Me.zgSummaryPlot.ScrollMaxY2 = 0
        Me.zgSummaryPlot.ScrollMinX = 0
        Me.zgSummaryPlot.ScrollMinY = 0
        Me.zgSummaryPlot.ScrollMinY2 = 0
        Me.zgSummaryPlot.Size = New System.Drawing.Size(200, 200)
        Me.zgSummaryPlot.TabIndex = 0
        '
        'cSummaryPlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.zgSummaryPlot)
        Me.Name = "cSummaryPlot"
        Me.Size = New System.Drawing.Size(200, 200)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents zgSummaryPlot As ZedGraph.ZedGraphControl

End Class
