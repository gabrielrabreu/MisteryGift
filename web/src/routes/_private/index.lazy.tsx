import { createLazyFileRoute } from "@tanstack/react-router";

export const Route = createLazyFileRoute("/_private/")({
  component: () => <div>Hello /_private/!</div>,
});
