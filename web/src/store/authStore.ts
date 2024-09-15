import { create } from "zustand";
import { devtools, persist } from "zustand/middleware";

interface AuthState {
  isAuthenticated: boolean;
  signin: () => void;
  signout: () => void;
}

const useAuthStore = create<AuthState>()(
  devtools(
    persist(
      (set) => ({
        isAuthenticated: true,
        signin: () => set(() => ({ isAuthenticated: true })),
        signout: () => set(() => ({ isAuthenticated: false })),
      }),
      { name: "authStore" }
    )
  )
);

export { useAuthStore };
