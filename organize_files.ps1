$installer = New-Object -ComObject WindowsInstaller.Installer
$db = $installer.OpenDatabase((Resolve-Path "extracted_msi/a0").Path, 0)

# Build file map
$view = $db.OpenView("SELECT File, Component_, FileName, FileSize FROM File")
$view.Execute()
$fileMap = @{}
while ($record = $view.Fetch()) {
    $fId = $record.StringData(1)
    $comp = $record.StringData(2)
    $name = $record.StringData(3)
    if ($name.Contains('|')) { $name = $name.Split('|')[1] }
    $fileMap[$fId] = @{ Name = $name; Component = $comp }
}

Write-Output ("Total files in database: " + $fileMap.Count)

# Let's extract cab1, cab2, cab3 if not already extracted
New-Item -ItemType Directory -Force -Path "extracted_raw" | Out-Null
New-Item -ItemType Directory -Force -Path "extracted_app" | Out-Null

$7z = "C:\Program Files\7-Zip\7z.exe"
& $7z e "extracted_msi_tables/cab1.cab" -o"extracted_raw" -y | Out-Null
& $7z e "extracted_msi_tables/cab2.cab" -o"extracted_raw" -y | Out-Null
& $7z e "extracted_msi_tables/cab3.cab" -o"extracted_raw" -y | Out-Null

# Rename and organize
$found = 0
$missing = 0
foreach ($kv in $fileMap.GetEnumerator()) {
    $fId = $kv.Key
    $realName = $kv.Value.Name
    $rawPath = Join-Path "extracted_raw" $fId
    if (Test-Path $rawPath) {
        $destPath = Join-Path "extracted_app" $realName
        Copy-Item -Path $rawPath -Destination $destPath -Force
        $found++
    } else {
        $missing++
    }
}
Write-Output "Mapped $found files successfully. Missing: $missing"
