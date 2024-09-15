import { createFileRoute, redirect, Outlet } from "@tanstack/react-router";

export const Route = createFileRoute("/auth")({
  beforeLoad: async ({ location }) => {
    if (false) {
      throw redirect({
        to: "/",
        search: {
          redirect: location.href,
        },
      });
    }
  },
  component: () => {
    return (
      <div className="flex h-screen">
        Auth Layout
        <Outlet />
      </div>
    );
  },
});
