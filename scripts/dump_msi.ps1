$installer = New-Object -ComObject WindowsInstaller.Installer
$db = $installer.OpenDatabase((Resolve-Path "extracted_msi/a0").Path, 0)
$view = $db.OpenView("SELECT File, FileName, FileSize FROM File")
$view.Execute()
$map = @{}
while ($record = $view.Fetch()) {
    $fileId = $record.StringData(1)
    $fileName = $record.StringData(2)
    if ($fileName.Contains('|')) {
        $fileName = $fileName.Split('|')[1]
    }
    $map[$fileId] = $fileName
}

Write-Output "MainExecutableFile is: $($map['MainExecutableFile'])"

Write-Output "`n--- Non-Microsoft / Application Executables and DLLs ---"
$map.GetEnumerator() | Where-Object { 
    $_.Value -notlike "System.*" -and 
    $_.Value -notlike "Microsoft.*" -and 
    $_.Value -notlike "*.resources.dll" -and
    $_.Value -notlike "Presentation*" -and
    $_.Value -notlike "WindowsBase*" -and
    $_.Value -notlike "UIAutomation*" -and
    $_.Value -notlike "clr*" -and
    $_.Value -notlike "mscor*" -and
    ($_.Value -like "*.exe" -or $_.Value -like "*.dll" -or $_.Value -like "*.json")
} | ForEach-Object { "$($_.Key) = $($_.Value)" }

Write-Output "`n--- All EXEs ---"
$map.GetEnumerator() | Where-Object { $_.Value -like "*.exe" } | ForEach-Object { "$($_.Key) = $($_.Value)" }

Write-Output "`n--- Custom Actions ---"
$caView = $db.OpenView("SELECT Action, Type, Source, Target FROM CustomAction")
$caView.Execute()
while ($caRec = $caView.Fetch()) {
    Write-Output ("CA: Action={0}, Type={1}, Source={2}, Target={3}" -f $caRec.StringData(1), $caRec.IntegerData(2), $caRec.StringData(3), $caRec.StringData(4))
}
