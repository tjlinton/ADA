$sqlService = 'MSSQL$TAJAYLINTON'
$sqlAgentService = 'SQLAgent$TAJAYLINTON'


function startMyService {
    param ([string] $serviceName)
    #end params

    $serviceObj = Get-Service -Name $serviceName
    $loopCount = 0
        
    while ($serviceObj.Status -ne 'Running') 
    {
        Start-Service $serviceName
        Write-Host ($serviceName + ' is ' + $serviceObj.status)
        Write-Host ('Starting service: ' + $serviceName)
        Start-Sleep 30
        $serviceObj.Refresh()

        if ($serviceObj.status -eq 'Running') {
            Write-Host ($serviceName + ' is now running')
        }

        $loopCount++
        if ($loopCount -eq 5) {
            Write-Host ('Unable to start service: ' + $serviceName)
            break
        } 

    }
}

startMyService -serviceName $sqlService
Write-Host "done"