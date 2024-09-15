import { createFileRoute, redirect, Outlet } from "@tanstack/react-router";

import { useAuthStore } from "@/store/authStore";

export const Route = createFileRoute("/_private")({
  beforeLoad: () => {
    const { isAuthenticated } = useAuthStore.getState();
    if (!isAuthenticated) {
      throw redirect({
        to: "/auth/signin",
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
