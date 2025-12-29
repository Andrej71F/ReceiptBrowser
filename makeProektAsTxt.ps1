$root = Get-Location
$outFile = "$root\all_code_clean.txt"

if (Test-Path $outFile) {
    Remove-Item $outFile
}

Get-ChildItem -Path $root -Recurse -Include *.cs, *.xaml |
    Where-Object { $_.FullName -notmatch '\\obj\\' -and $_.FullName -notmatch '\\bin\\' -and $_.FullName -notmatch '\\vs\\'} |
    Sort-Object FullName |
    ForEach-Object {
        "===================="           | Out-File -FilePath $outFile -Append -Encoding UTF8
        "FILE: $($_.FullName)"          | Out-File -FilePath $outFile -Append -Encoding UTF8
        "====================`r`n"      | Out-File -FilePath $outFile -Append -Encoding UTF8

        Get-Content $_.FullName -Raw    | Out-File -FilePath $outFile -Append -Encoding UTF8
        "`r`n`r`n"                      | Out-File -FilePath $outFile -Append -Encoding UTF8
    }