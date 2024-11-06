# Solution Renamer for Visual Studio Projects

> **Warning**: **Do not use this tool on live production projects!** Always make a backup of your solution before using this tool. Test it on a copy of your project first to ensure everything works correctly.

This application allows you to rename a Visual Studio solution, its projects, associated files, and folders in bulk. It replaces all occurrences of the old solution name with the new one across the solution’s files, renames project folders and files, and even renames the solution file itself.

## Features

- **Rename Solution Name**: Update the name of the solution and all related project files and folders.
- **Folder and File Renaming**: Automatically renames folders and files containing the old solution name.
- **Text Search and Replace**: Searches for all occurrences of the old solution name inside project files and replaces them with the new solution name.
- **File and Folder Access Handling**: Skips read-only files, handles access errors, and logs any issues encountered during the process.
- **Visual Feedback**: Displays the renaming process and any errors in real-time via a logging textbox in the application’s UI.
- **Automatic Solution File Rename**: Automatically renames the solution (.sln) file if it hasn’t already been renamed.

## Requirements

- **.NET Framework 4.7.2** or higher
- Visual Studio (to open and load .sln files)

## Installation

1. **Clone or Download the Repository**:
   - Clone the repository using Git:
     ```bash
     git clone https://github.com/benyowszky/solution-renamer.git
     ```
   - Or download the ZIP file and extract it to your preferred directory.

2. **Open the Project in Visual Studio**:
   - Open the solution file in Visual Studio (`SolutionRenamer.sln`).

3. **Build the Project**:
   - Build the project to ensure all dependencies are restored.

4. **Run the Application**:
   - After building, you can run the application from within Visual Studio or directly from the output directory.

## Usage

### How to Use the Solution Renamer:

1. **Open the Solution File**:
   - Click the "Open Solution" button to select and load the Visual Studio solution file (`.sln`) that you want to rename.

2. **Enter the New Solution Name**:
   - In the "New Solution Name" textbox, type the new name you wish to assign to the solution.

3. **Start the Renaming Process**:
   - Click the "Rename Solution" button to begin renaming the solution. The application will:
     - Rename project folders and files.
     - Replace occurrences of the old solution name in all relevant project files.
     - Rename the `.sln` solution file.
     - Rename the main project folder if necessary.

4. **Monitor Progress**:
   - You will see a log of the renaming process in the `txtLog` textbox. It will display the steps being taken and any errors encountered along the way. The log will look something like this:
   ```
   Starting rename process...
   Renamed solution file: OldSolution.sln to NewSolution.sln
   Renamed folder: OldSolutionFolder to NewSolutionFolder
   Updated content in file: C:\Path\To\Project\File.vb
   Solution rename process complete!
   ```

5. **Check for Errors**:
   - If there are any files or folders that cannot be renamed, you will see error messages in the log.

6. **Verify the Solution**:
   - After renaming is complete, open the renamed solution in Visual Studio to verify that everything was renamed correctly and is working as expected.

## Example Walkthrough

1. **Load Solution**: Select your solution file (e.g., `OldSolution.sln`).
2. **Enter New Name**: Enter `NewSolution` as the new solution name.
3. **Rename**: The application will automatically:
   - Replace `OldSolution` with `NewSolution` inside all project files.
   - Rename all folders containing `OldSolution` to `NewSolution`.
   - Rename the solution file from `OldSolution.sln` to `NewSolution.sln`.
4. **Log Output**: The `txtLog` will display messages like:
   ```
   Starting rename process...
   Renamed solution file: OldSolution.sln to NewSolution.sln
   Renamed folder: OldSolutionFolder to NewSolutionFolder
   Updated content in file: C:\Path\To\Project\File.vb
   Solution rename process complete!
   ```

## Troubleshooting

- **Access Denied**: If you encounter access denied errors, ensure no applications (such as Visual Studio) are currently using the solution or its files.
- **File Not Found**: This can occur if the solution file has already been renamed or moved. Double-check the file paths.

## Contributing

If you'd like to contribute to this project, feel free to fork the repository, make your changes, and submit a pull request. Contributions are welcome for bug fixes, feature enhancements, or documentation improvements.

### Steps for Contributing:
1. Fork the repository
2. Create a new branch for your feature (`git checkout -b feature-name`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature-name`)
5. Create a pull request from your branch to the main branch of this repository

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
