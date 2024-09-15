import { createFileRoute, redirect, Outlet } from "@tanstack/react-router";

import { useAuthStore } from "@/store/authStore";

export const Route = createFileRoute("/auth")({
  beforeLoad: () => {
    const { isAuthenticated } = useAuthStore.getState();
    if (isAuthenticated) {
      throw redirect({
        to: "/",
      });
    }
  },
  component: () => {
    return (
      <div className="flex h-screen">
        <Outlet />
      </div>
    );
  },
});
