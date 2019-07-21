Get-Process | Where-Object {$_.Path -like "*chromedriver*"}
Get-Process | Where-Object {$_.Path -like "*chromedriver*"} | Stop-Process