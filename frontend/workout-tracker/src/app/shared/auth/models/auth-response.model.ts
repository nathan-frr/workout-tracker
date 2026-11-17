export interface AuthResponse {
  id: string;
  email: string;
  firstName: string | null;
  lastName: string | null;
}

export interface LoginRequest {
  email: string;
  password: string;
  rememberMe: boolean;
}

export interface RegisterRequest {
  email: string;
  password: string;
  firstName: string | null;
  lastName: string | null;
}