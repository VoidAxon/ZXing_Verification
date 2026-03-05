# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

ZXing_Verification is a Windows Forms application (.NET Framework 4.8) for verifying and testing ZXing barcode/QR code functionality. The application provides a simple GUI to generate QR codes from user input text.

## Build and Run

**Building the solution:**
```bash
# Build in Debug mode (x64)
msbuild ZXing_Verification.sln /p:Configuration=Debug /p:Platform="Any CPU"

# Build in Release mode
msbuild ZXing_Verification.sln /p:Configuration=Release /p:Platform="Any CPU"
```

**Running the application:**
- Launch from Visual Studio 2022 (F5 for debug, Ctrl+F5 for run without debugging)
- Or run the built executable: `ZXing_Verification\bin\Debug\ZXing_Verification.exe`

## Architecture

**Single-Project Windows Forms Application:**
- `Program.cs` - Application entry point with standard Windows Forms initialization
- `Form1.cs` - Main form with QR code generation logic
- `Form1.Designer.cs` - Auto-generated UI designer code

**Key Components:**
- **ZXing Library**: Uses a local DLL reference (`lib\zxing.dll` version 0.16.6.0) for barcode operations
- **BarcodeWriter**: Generates QR codes from text input (200x200 pixels)
- **BarcodeReader**: Instantiated in Form1 constructor for potential future read operations
- **UI Elements**: TextBox (txt), PictureBox (pic), Button (btn - labeled "QR生成")

**Platform Configuration:**
- Debug build targets x64 specifically (line 17 in .csproj: `<PlatformTarget>x64</PlatformTarget>`)
- Release build uses AnyCPU
- Framework: .NET Framework 4.8

## Dependencies

The ZXing library is referenced as a local assembly (not via NuGet):
- Located at: `ZXing_Verification\lib\zxing.dll`
- Strong-named assembly with PublicKeyToken: 4e88037ac681fe60
- When modifying ZXing functionality, ensure the local DLL matches the expected version

## Code Patterns

**QR Code Generation Flow** (Form1.cs:17-40):
1. Button click event (`btn_Click`) captures text input
2. Creates BarcodeWriter with QR_CODE format
3. Sets encoding options (200x200 dimensions)
4. Uses fallback text "Test" if input is empty or whitespace
5. Writes bitmap to PictureBox control
6. Chinese error messages on exception: "错误: "

**Language Notes:**
- UI contains Japanese comments (デザイナー, リソース)
- Button label is in Japanese: "QR生成" (QR Generation)
- Error messages are in Chinese: "错误"
