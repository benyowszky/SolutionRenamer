Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class frmMain

    Private currentSolutionPath As String
    Private currentSolutionName As String

    Private Sub LogMessage(message As String)
        txtLog.AppendText(message & Environment.NewLine)
    End Sub

    Private Sub btnOpenSolution_Click(sender As Object, e As EventArgs) Handles btnOpenSolution.Click
        Using openFileDialog As New OpenFileDialog
            openFileDialog.Filter = "Solution Files (*.sln)|*.sln"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                currentSolutionPath = openFileDialog.FileName
                currentSolutionName = Path.GetFileNameWithoutExtension(currentSolutionPath)
                txtCurrentSolutionName.Text = currentSolutionName
                LogMessage($"Loaded solution: {currentSolutionName}")
            End If
        End Using
    End Sub

    Private Sub btnRenameSolution_Click(sender As Object, e As EventArgs) Handles btnRenameSolution.Click
        If String.IsNullOrEmpty(currentSolutionPath) OrElse String.IsNullOrEmpty(txtNewSolutionName.Text) Then
            MessageBox.Show("Please load a solution and enter a new solution name.")
            Return
        End If

        Dim newSolutionName As String = txtNewSolutionName.Text
        Dim solutionDirectory = Path.GetDirectoryName(currentSolutionPath)

        LogMessage("Starting rename process...")

        ' Step 1: Replace content within files
        Dim files = Directory.GetFiles(solutionDirectory, "*.*", SearchOption.AllDirectories) _
                            .Where(Function(file) Not file.Contains(Path.Combine(solutionDirectory, ".vs"))).ToList()

        For Each filePath In files
            Try
                If File.GetAttributes(filePath).HasFlag(FileAttributes.ReadOnly) Then
                    LogMessage($"Skipping read-only file: {filePath}")
                    Continue For
                End If

                Dim fileContent As String = File.ReadAllText(filePath)
                Dim updatedContent As String = fileContent.Replace(currentSolutionName, newSolutionName)

                If fileContent <> updatedContent Then
                    File.WriteAllText(filePath, updatedContent)
                    LogMessage($"Updated content in file: {filePath}")
                End If
            Catch ex As UnauthorizedAccessException
                LogMessage($"Access denied: {filePath}")
            Catch ex As IOException
                LogMessage($"Error processing file {filePath}: {ex.Message}")
            End Try
        Next

        ' Step 2: Rename folders containing the old solution name
        Dim directories = Directory.GetDirectories(solutionDirectory, "*", SearchOption.AllDirectories).OrderByDescending(Function(d) d.Length).ToList()

        For Each directoryPath In directories
            If Path.GetFileName(directoryPath).Contains(currentSolutionName) Then
                Try
                    Dim newDirectoryPath = Path.Combine(Path.GetDirectoryName(directoryPath), Path.GetFileName(directoryPath).Replace(currentSolutionName, newSolutionName))
                    Directory.Move(directoryPath, newDirectoryPath)
                    LogMessage($"Renamed folder: {directoryPath} to {newDirectoryPath}")

                    ' Update any references to the old folder path in files
                    For Each filePath In files
                        Try
                            Dim fileContent As String = File.ReadAllText(filePath)
                            Dim updatedContent As String = fileContent.Replace(directoryPath, newDirectoryPath)
                            If fileContent <> updatedContent Then
                                File.WriteAllText(filePath, updatedContent)
                                LogMessage($"Updated folder path in file: {filePath}")
                            End If
                        Catch ex As UnauthorizedAccessException
                            LogMessage($"Access denied: {filePath}")
                        Catch ex As IOException
                            LogMessage($"Error updating path in file {filePath}: {ex.Message}")
                        End Try
                    Next

                Catch ex As UnauthorizedAccessException
                    LogMessage($"Access denied: {directoryPath}")
                Catch ex As IOException
                    LogMessage($"Error renaming folder {directoryPath}: {ex.Message}")
                End Try
            End If
        Next

        ' Step 3: Rename files with the old solution name in their filename
        For Each filePath In files
            Dim fileName = Path.GetFileName(filePath)
            If fileName.Contains(currentSolutionName) Then
                Try
                    Dim newFileName = fileName.Replace(currentSolutionName, newSolutionName)
                    Dim newFilePath = Path.Combine(Path.GetDirectoryName(filePath), newFileName)
                    File.Move(filePath, newFilePath)
                    LogMessage($"Renamed file: {filePath} to {newFilePath}")
                Catch ex As UnauthorizedAccessException
                    LogMessage($"Access denied: {filePath}")
                Catch ex As IOException
                    LogMessage($"Error renaming file {filePath}: {ex.Message}")
                End Try
            End If
        Next

        ' Step 4: Rename the main solution file only if not already renamed
        Dim newSolutionFilePath = Path.Combine(solutionDirectory, newSolutionName & ".sln")
        If currentSolutionPath <> newSolutionFilePath AndAlso File.Exists(currentSolutionPath) Then
            Try
                File.Move(currentSolutionPath, newSolutionFilePath)
                LogMessage($"Renamed solution file: {currentSolutionPath} to {newSolutionFilePath}")
                currentSolutionPath = newSolutionFilePath ' Update path to new solution file
            Catch ex As UnauthorizedAccessException
                LogMessage($"Access denied when renaming solution file: {ex.Message}")
            Catch ex As IOException
                LogMessage($"Error renaming solution file: {ex.Message}")
            End Try
        End If

        ' Step 5: Rename the main project folder (solution directory)
        Dim parentDirectory = Path.GetDirectoryName(solutionDirectory)
        Dim newSolutionDirectory = Path.Combine(parentDirectory, newSolutionName)
        If Directory.Exists(solutionDirectory) Then
            Try
                If solutionDirectory <> newSolutionDirectory Then
                    Thread.Sleep(500)  ' Delay to ensure no lingering file handles
                    Directory.Move(solutionDirectory, newSolutionDirectory)
                    LogMessage($"Renamed main project folder: {solutionDirectory} to {newSolutionDirectory}")
                End If
            Catch ex As UnauthorizedAccessException
                LogMessage($"Access denied when renaming main project folder: {ex.Message}")
            Catch ex As IOException
                LogMessage($"Error renaming main project folder: {ex.Message}")
            End Try
        Else
            LogMessage($"Main project folder not found: {solutionDirectory}")
        End If

        LogMessage("Solution rename process complete!")
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display usage instructions at startup
        DisplayInstructions()
    End Sub

    Private Sub DisplayInstructions()
        txtLog.Clear()
        txtLog.AppendText("Usage Instructions:" & Environment.NewLine)
        txtLog.AppendText("1. Click 'Open Solution' to load a Visual Studio solution file (.sln)." & Environment.NewLine)
        txtLog.AppendText("2. The current solution name will be displayed automatically." & Environment.NewLine)
        txtLog.AppendText("3. Enter the new solution name in the provided text box." & Environment.NewLine)
        txtLog.AppendText("4. Click 'Rename Solution' to start the renaming process." & Environment.NewLine)
        txtLog.AppendText("5. The application will:" & Environment.NewLine)
        txtLog.AppendText("   - Replace occurrences of the old solution name inside all project files." & Environment.NewLine)
        txtLog.AppendText("   - Rename folders and files containing the old solution name." & Environment.NewLine)
        txtLog.AppendText("   - Rename the solution (.sln) file itself." & Environment.NewLine)
        txtLog.AppendText("   - Finally, rename the main project folder if necessary." & Environment.NewLine)
        txtLog.AppendText("6. Check the log messages below for details of each step, including any errors encountered." & Environment.NewLine)
        txtLog.AppendText("7. Ensure no other applications (e.g., Visual Studio) are using the files during renaming." & Environment.NewLine)
        txtLog.AppendText("8. Once the renaming is complete, verify the solution by opening it in Visual Studio." & Environment.NewLine)
        txtLog.AppendText("-----------------------------------------------------------" & Environment.NewLine)
    End Sub
End Class
