import { createLazyFileRoute } from "@tanstack/react-router";

export const Route = createLazyFileRoute("/auth/signin")({
  component: () => <div>Hello /_auth/signin!</div>,
});
