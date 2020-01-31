# Tom Hollis LLC Active Directory setup script for users and OUs
#
# Author: Tom Hollis
# Jan 2020
#

## ************************************************************
##
## NOTE: This doesn't work yet - Ran out of time and took the instructor's 
##       option to complete this assignment without Powershell
##
## TODO: Figure out how to reliably work with collections in PS
##       (this should solve the biggest remaining issues)
##       Might also be a problem in the loops at the bottom
##
##   OR: Even better - Actually implement a tree structure
##
## ************************************************************

#Add-Type -AssemblyName System.Collections.Generic

# assuming everything is set up properly -- would ideally have some checks here
# also omitting input validation for time reasons -- this is super wrong

"Welcome to the shell script for adding users and organizational units"
"---------------------------------------------------------------------"
""

$domain = "tom.ca"          #this shouldn't be hard coded
$basepath = "DC=tom,DC=ca" #this shouldn't be hard coded
$path = $basepath
$doneYet = $false # controls whether the loop below continues
$countries = [Collections.Generic.List[string]]::new()       #all countries are off the root
$cities = [Collections.Generic.Dictionary[string,int]]::new()  #cities must be paired with a country (index of $countries)
$depts = [Collections.Generic.Dictionary[string,int]]::new()   #depts must be paired with a city (index of $cities)
$users = [Collections.Generic.Dictionary[string,int]]::new()   #users must be paired with a dept (index of $depts)
                                                                    #a tree object would have been better

# ideally would fill the above collections with already-existing OUs at this point

DO
{
    #   enter user info: first name, last name, password
    "Please enter information for a user"
    $FirstName = Read-Host -Prompt "First Name: "
    $LastName = Read-Host -Prompt "Last Name: "
    $Password = Read-Host -Prompt "Temporary Password: "

    #   country OU or make one
    $i = 0
    $country = -1
    
    if($countries.Count -gt 0){ #if there are countries already, display them as options
        foreach($object in $countries){
            Write-Host "$($i+1): $object" #present the countries with human indexing (starting from 1)
            $i++ 
        }
        Write-Host "0:  Add a New Country"
        $country = [int](Read-Host -Prompt "Which Country is $FirstName in? ") 
        $country-- #translate to machine indexing (starting from 0)

    }
    if ($country -eq -1){ #if there aren't countries already, or adding was selected above
        $input = Read-Host -Prompt "What is the name of $FirstName's country? "
        $countries.add($input)
        $country=$countries.count - 1  #the country is now the last one in the list
        $path = "OU=" + $input + ',' + $path #update the path
        New-ADOrganizationalUnit -Name "$input" -Path "$path"   #create the country OU
    } else {

        $path = "OU=" + $countries[$country] + ',' + $path #update the path
    }

    #   city OU or make one
    $i=0
    $city = -1
    if($cities.count -gt 0){ #if we have any cities to display...
        foreach($key in $cities.keys){ 
            if($cities[$key] -eq $country){ #get only the cities in the country selected above
                Write-Host "$($i+1): $key"
                $i++
            }
        }
        if($i -gt 0){ #only if we actually found any cities to write out above
            Write-Host "0: Add a New City"
            $city = [int](Read-Host -Prompt "Which City is $FirstName in? ")
            $city--;
        }        
    }
    if($city -eq -1){ #if there aren't any cities or add a city was selected
        $input = Read-Host -Prompt "What is the name of $FirstName's city? "
        $cities.add($input, $country)
        $city=$cities.count - 1
        $path = "OU=" + $input + ',' + $path #update the path
        New-ADOrganizationalUnit -Name "$input" -Path "$path"   #create the city OU
    } else {
        $path = "OU=" + $cities.keys[$city] + ',' + $path #update the path
    }

    #   department OU or make one (make User & Computer OUs if not exist)
    $i=0
    $dept = -1
    if($depts.count -gt 0){ #if we have any depts to display...
        foreach($key in $depts.keys){ 
            if($depts[$key] -eq $city){ #get only the depts in the country selected above
                Write-Host "$($i+1): $key"
                $i++
            }
        }
        if($i -gt 0){ #only if we actually found any depts to write out above
            Write-Host "0: Add a New Department"
            $dept = [int](Read-Host -Prompt "Which Department is $FirstName in? ")
            $dept--;
        }        
    }
    if($dept -eq -1){ #if there aren't any departments or add a department was selected
        $input = Read-Host -Prompt "What is the name of $FirstName's department? "
        $depts.add($input, $city)
        $dept=$depts.count - 1
        New-ADOrganizationalUnit -Name "$input" -Path "$path"   #create the department OU
        $path = "OU=" + $input + "," + $path #update the path
        New-ADOrganizationalUnit -Name "Users" -Path "$path"        #give it the leaf nodes it needs
        New-ADOrganizationalUnit -Name "Computers" -Path "$path"
        $path = "OU=Users,"+ $path #update the path
    } else {
        $path = "OU=Users,OU=" + $depts.keys[$dept] + ',' + $path #update the path
    }
    Write-Host "$path"
        
    
    #add to the list for printing later
    $users.add($($firstname+" "+$lastname), $dept)  

    # do the actual assigning
    New-ADUser -Name "$firstname $lastname" -GivenName "$firstname" -Surname "$lastname" -SamAccountName "$firstname$lastname" -UserPrincipalName "$($firstname+$lastname)@tom.ca" `
                -AccountPassword (ConvertTo-SecureString $password -AsPlainText -force) -Enabled $true -Path "$path"

    #   ask if we're making another user
    $input = Read-Host -Prompt "Should we make another user? (Y/N)"
    if (($input -eq "N") -or ($input -eq "n")){
        $doneyet = $true
    }

    $path = $basepath #reset to start over

} While (!$doneYet) 


# output tree structure -- very inefficient without knowledge of a tree object yet, but gets the job done

$i = 0
# for each country, output country name
foreach($country in $countries){
    Write-Host "$country"

    $j = 0
    # look for a city that references it, output with 1 indent if so
    foreach($city in $cities.keys){

        if($cities[$city] -eq $i){ #if the city's country is the current country's index, print
            Write-Host "|-$city"
            # look for a dept that references that city, output with 2 indents if so, plus Users with 3 indents
            $k =0
            foreach($dept in $depts.keys){
                if($depts[$dept] -eq $j){
                    Write-Host "||-$dept"
                    Write-Host "|||-Users"

                    # look for a user in that dept, output with 4 indents if so
                    
                    foreach($user in $users.keys){
                        if($users[$user] -eq $k){
                            Write-Host "||||-$($firstname) $lastname"
                        }
                    }
                }               

                $k++
            }
        }  
      
        $j++
    }

    $i++
}




