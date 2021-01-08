function Write-Log {
    param (
        $Output
    )

    Write-Host $Output -ForegroundColor Green
}

Write-Log @"
Building EditorJS Library 
---
Installing dependencies...
"@

cd ./src

yarn install 

Write-Log "Building dev bundle..."

yarn run build

Write-Log "Building prod bundle..." 

yarn run build:prod

Write-Log "Building Razor library..."

dotnet build
cd ..

Write-Log "Lib built successfully!"

