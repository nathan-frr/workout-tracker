import { HttpErrorResponse } from '@angular/common/http';
import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginForm } from './login-form';
import { LoginRequest } from '../../shared/auth/models/auth-response.model';
import { AuthService } from '../../shared/auth/auth.service';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'login-screen',
  styleUrl: './login-screen.scss',
  templateUrl: './login-screen.html',
})
export class LoginScreen {
  private readonly authService = inject(AuthService);

  private fb = inject(FormBuilder);
  private router = inject(Router);

  error = signal<string | null>(null);
  rememberMe = signal(true);

  loginForm: LoginForm = this.fb.group({
    email: this.fb.nonNullable.control('', Validators.required),
    password: this.fb.nonNullable.control('', Validators.required),
    rememberMe: this.fb.nonNullable.control(true)
  })

  register(): void {
    this.router.navigate(["/register"])
  }

  rememberOnClick(): void {
    const rememberMe = !this.rememberMe();

    this.rememberMe.set(rememberMe);
    this.loginForm.controls.rememberMe.setValue(rememberMe);
  }

  login(): void {
    this.error.set(null);

    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }
    const request: LoginRequest = this.loginForm.getRawValue();

    this.authService.login(request).subscribe({
      next: () => {
        this.router.navigate(['']);
      },
      error: (error: HttpErrorResponse) => {
        const message = typeof error.error === 'string'
          ? error.error
          : error.error?.detail;

        this.error.set(message || 'Unable to sign in. Please check your details and try again.');
      }
    });
  }
}
