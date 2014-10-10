function CheckPasswordExpire()
{
    
    Param ([Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true, HelpMessage = "Identity of the Account")]
        
        [Object] $accountIdentity)
    
    PROCESS
    {
        
        $accountObj = Get-ADUser $accountIdentity -properties PasswordExpired, PasswordNeverExpires, PasswordLastSet
        
        if ($accountObj.PasswordExpired)
        {
            
            return ("Password of account: " + $accountObj.Name + " already expired!")
            
        }
        else
        {
            
            if ($accountObj.PasswordNeverExpires)
            {
                
                return ("Password of account: " + $accountObj.Name + " is set to never expires!")
                
            }
            else
            {
                
                $passwordSetDate = $accountObj.PasswordLastSet
                
                if ($passwordSetDate -eq $null)
                {
                    
                    return ("Password of account: " + $accountObj.Name + " has never been set!")
                    
                }
                else
                {
                    
                    $maxPasswordAgeTimeSpan = $null
                    
                    $dfl = (get-addomain).DomainMode
                    
                    if ($dfl -ge 3)
                    {
                        
                        ## Greater than Windows2008 domain functional level
                        
                        $accountFGPP = Get-ADUserResultantPasswordPolicy $accountObj
                        
                        if ($accountFGPP -ne $null)
                        {
                            
                            $maxPasswordAgeTimeSpan = $accountFGPP.MaxPasswordAge
                            
                        }
                        else
                        {
                            
                            $maxPasswordAgeTimeSpan = (Get-ADDefaultDomainPasswordPolicy).MaxPasswordAge
                            
                        }
                        
                    }
                    else
                    {
                        
                        $maxPasswordAgeTimeSpan = (Get-ADDefaultDomainPasswordPolicy).MaxPasswordAge
                        
                    }
                    
                    if ($maxPasswordAgeTimeSpan -eq $null -or $maxPasswordAgeTimeSpan.TotalMilliseconds -eq 0)
                    {
                        
                        return ("MaxPasswordAge is not set for the domain or is set to zero!")
                        
                    }
                    else
                    {
                        
                        return ("Password of account: " + $accountObj.Name + " is not expired and expires on: " + ($passwordSetDate + $maxPasswordAgeTimeSpan))
                        
                    }
                    
                }
                
            }
            
        }
        
    }
    }

    Add-Type -AssemblyName "microsoft.visualbasic" -ErrorAction Stop
    
    $Default = $null
    $Title = "Account Expiration Information"
    $Prompt = "Enter the user's username"
    
    $accountIdentity = [microsoft.visualbasic.interaction]::InputBox($Prompt, $Title, $Default)
    if ($accountIdentity)
    {
        $output = CheckPasswordExpire($accountIdentity)
        [microsoft.visualbasic.interaction]::MsgBox($output, "OKOnly,Information", $Title)
    }
    else
    {
        exit /B 1
    }