function CheckPasswordExpire() {

    Param ([Parameter(Mandatory=$true,  Position=0,  ValueFromPipeline=$true, HelpMessage="Identity of the Account")]

    [Object] $accountIdentity)

    PROCESS {

        $accountObj = Get-ADUser $accountIdentity -properties PasswordExpired, PasswordNeverExpires, PasswordLastSet

        if ($accountObj.PasswordExpired) {

            return ("Password of account: " + $accountObj.Name + " already expired!")

        } else { 

            if ($accountObj.PasswordNeverExpires) {

                return ("Password of account: " + $accountObj.Name + " is set to never expires!")

            } else {

                $passwordSetDate = $accountObj.PasswordLastSet

                if ($passwordSetDate -eq $null) {

                    return ("Password of account: " + $accountObj.Name + " has never been set!")

                }  else {

                    $maxPasswordAgeTimeSpan = $null

                    $dfl = (get-addomain).DomainMode

                    if ($dfl -ge 3) { 

                        ## Greater than Windows2008 domain functional level

                        $accountFGPP = Get-ADUserResultantPasswordPolicy $accountObj

                        if ($accountFGPP -ne $null) {

                            $maxPasswordAgeTimeSpan = $accountFGPP.MaxPasswordAge

                        } else {

                            $maxPasswordAgeTimeSpan = (Get-ADDefaultDomainPasswordPolicy).MaxPasswordAge

                        }

                    } else {

                        $maxPasswordAgeTimeSpan = (Get-ADDefaultDomainPasswordPolicy).MaxPasswordAge

                    }

                    if ($maxPasswordAgeTimeSpan -eq $null -or $maxPasswordAgeTimeSpan.TotalMilliseconds -eq 0) {

                        return ("MaxPasswordAge is not set for the domain or is set to zero!")

                    } else {

                        return ("Password of account: " + $accountObj.Name + " is not expired and expires on: " + ($passwordSetDate + $maxPasswordAgeTimeSpan))

                    }

                }

            }

        }

    }

}


    Add-Type -AssemblyName "microsoft.visualbasic" -ErrorAction Stop
    
    $Default = $null
    $Title = "Reset Password"

    $Prompt = "Enter the user's username"

    $accountIdentity = [microsoft.visualbasic.interaction]::InputBox($Prompt,$Title,$Default)
    if($accountIdentity){

        $expired = CheckPasswordExpire($accountIdentity)

        $Prompt = $expired
        [microsoft.visualbasic.interaction]::MsgBox($Prompt,'OKOnly,Information',$Title)

        $WID = Get-ADUser $accountIdentity -Properties EmployeeID

        $FullName = $WID.Name

        $WID = $WID.EmployeeID.Substring(3)

        $Prompt = "Would you like to reset the password for $FullName ($accountIdentity)?"

        $answer = [microsoft.visualbasic.interaction]::MsgBox($Prompt,"YesNo,Question",$Title)


        if($answer -eq 6){
            $Prompt = "Please confirm that the W# for $FullName ($accountIdentity) is $WID"
            $answer = [microsoft.visualbasic.interaction]::MsgBox($Prompt,"YesNo,Question",$Title)
            if($answer -ieq 'y') {
                $newpassword = "WIT1$" + "$WID"
                $newpassword = ConvertTo-SecureString $newpassword -asplaintext -force
                $paramHash = @{
                    Identity = $accountIdentity
                    NewPassword = $newpassword
                    Reset = $True
                    Passthru = $True
                    ErrorAction = "Stop"
                }
 
                Try {
                    $output = Set-ADAccountPassword @paramHash |
                    Set-ADUser -ChangePasswordAtLogon $True -PassThru |
                    Get-ADuser -Properties PasswordLastSet,PasswordExpired,WhenChanged | Out-String
                    $Prompt = "View Account Information?"
                    $answer = [microsoft.visualbasic.interaction]::MsgBox($Prompt,"YesNo,Question",$Title)
                    if($answer -eq 6) {
                        [microsoft.visualbasic.interaction]::MsgBox($output,"OKOnly,Information",$Title)
                        exit
                    } else { 
                        exit
                    }
                }
                Catch {
                    $Prompt =  "Failed to reset password for $accountIdentity. $($_.Exception.Message)"
                    [microsoft.visualbasic.interaction]::MsgBox($Prompt,"OKOnly,Information",$Title)
                }
            } else {
                exit
            }
        } else {
            exit
        }
    }
# SIG # Begin signature block
# MIID7QYJKoZIhvcNAQcCoIID3jCCA9oCAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUmseDrQOM8GjJ1RUbiyHazO+a
# Q6OgggINMIICCTCCAXagAwIBAgIQVu9o4EHJyqdL38OPyP/yQTAJBgUrDgMCHQUA
# MBYxFDASBgNVBAMTC05laWwgSGFubG9uMB4XDTE0MDcyMTE5MzczNFoXDTM5MTIz
# MTIzNTk1OVowFjEUMBIGA1UEAxMLTmVpbCBIYW5sb24wgZ8wDQYJKoZIhvcNAQEB
# BQADgY0AMIGJAoGBAKU1eTvWdmN3oanCV9MVc3E33yknL+yLQSKN3ZRXudoSCeKO
# gkpyX7hZvbCdPbPYs5V83zQxL8XeWWtlbMMeywroxyiz/Hov0swXbXuLynDRIaD2
# 9nwIB4OvqREfECHjhOv/HhAoA0InEqpR3+jgFnZ9iYMAN2fDdzPwbBtTM+XzAgMB
# AAGjYDBeMBMGA1UdJQQMMAoGCCsGAQUFBwMDMEcGA1UdAQRAMD6AEOG9y7VCo/bN
# ngeOC0XGPDShGDAWMRQwEgYDVQQDEwtOZWlsIEhhbmxvboIQVu9o4EHJyqdL38OP
# yP/yQTAJBgUrDgMCHQUAA4GBABusIEKpew1klZmZxaO/nylIGy4N0KbZ5aFm3rya
# EzJ5Z/NnlQyGGApGVw2aTwkWXDTkvsUNP6/rkBoCgRX5fJ0znTpvS+FvW6fkdqoR
# msFujXnos5xJutN+BCn3PiB2Jx5AGqaMoDN2m+X0KNss23ByhWUjjsOfgbajJVnf
# FLS+MYIBSjCCAUYCAQEwKjAWMRQwEgYDVQQDEwtOZWlsIEhhbmxvbgIQVu9o4EHJ
# yqdL38OPyP/yQTAJBgUrDgMCGgUAoHgwGAYKKwYBBAGCNwIBDDEKMAigAoAAoQKA
# ADAZBgkqhkiG9w0BCQMxDAYKKwYBBAGCNwIBBDAcBgorBgEEAYI3AgELMQ4wDAYK
# KwYBBAGCNwIBFTAjBgkqhkiG9w0BCQQxFgQUd8mVisFrVYYylZU40rrn490TnHIw
# DQYJKoZIhvcNAQEBBQAEgYCYqDzPLaUnwocq5qZa3tkMX3PmDUrc1mChPf0La2U+
# TLjqtndBO9CJ8U0VCqsXR2VU4xirYTxH3XtKHfrGbRd91umF8VTnEjhv9dRPdt0z
# R4dwzpeHXCkiKuNCL20WBtuyU3y4bdyCVw+vgEb6WsK46/Yu7pD+fV1VO/5+EKB9
# 0Q==
# SIG # End signature block
