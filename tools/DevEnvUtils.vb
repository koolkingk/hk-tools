Imports EnvDTE
Imports System.Diagnostics
Imports System

Public Module DevEnvUtils
    Sub FindHeaderOrCodeFile()
        Dim szFileName As String, szExt As String, szAltFileName As String
        Dim iIndex As Int32

        DTE.StatusBar.Text = "Switching To Header Or Code File"

        szFileName = DTE.ActiveDocument.FullName

        ' Get Filename extension and alternative
        iIndex = szFileName.LastIndexOf(".")
        If iIndex > 0 Then
            szExt = szFileName.Substring(iIndex)
            If szExt = ".h" Then
                szAltFileName = szFileName.Replace(szExt, ".cpp")
            ElseIf szExt = ".cpp" Then
                szAltFileName = szFileName.Replace(szExt, ".h")
            Else
                szAltFileName = ""
            End If

            DTE.StatusBar.Text = "Switching To " + szAltFileName

            If szAltFileName <> "" Then
                DTE.ItemOperations.OpenFile(szAltFileName)
            End If

            DTE.StatusBar.Text = ""
        End If
    End Sub
End Module

