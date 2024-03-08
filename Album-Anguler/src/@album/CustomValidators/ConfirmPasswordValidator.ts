import { AbstractControl } from "@angular/forms";


export function ConfirmPasswordValidators(control:AbstractControl)
{
    const password=control.get('password');
    const confirmpassword=control.get('confirmPassword');

    if(password?.pristine || confirmpassword?.pristine)
    {
        return null;
    }
    else
    {
        return password && confirmpassword && password.value != confirmpassword.value
        ?{'misMatch':true} : null;
    }
}