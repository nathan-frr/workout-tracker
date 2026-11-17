import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../shared/auth/auth.service';
import { Router } from '@angular/router';
import { RegisterForm } from './register-form';
import { RegisterRequest } from '../../shared/auth/models/auth-response.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'register-screen',
  styleUrl: './register-screen.scss',
  templateUrl: './register-screen.html',
})
export class RegisterScreen {
  private readonly authService = inject(AuthService);

  private fb = inject(FormBuilder);
  private router = inject(Router);

  error = signal<string | null>(null);

  registerForm: RegisterForm = this.fb.group({
    email: this.fb.nonNullable.control('', Validators.required),
    password: this.fb.nonNullable.control('', Validators.required),
    firstName: this.fb.control(''),
    lastName: this.fb.control('')
  })

  register(): void {
    this.error.set(null);

    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }
    const request: RegisterRequest = this.registerForm.getRawValue();

    this.authService.register(request).subscribe({
      next: () => {
        this.router.navigate(['']);
      },
      error: (error: HttpErrorResponse) => {
        const message = typeof error.error === 'string'
          ? error.error
          : error.error?.detail;

        this.error.set(message || 'Unable to register. Please try again.');
      }
    });
  }

  login(): void {
    this.router.navigate(['/login']);
  }
}
