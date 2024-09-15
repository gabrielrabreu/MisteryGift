import { createLazyFileRoute } from "@tanstack/react-router";

export const Route = createLazyFileRoute("/_private/about")({
  component: () => <div>Hello /_private/about!</div>,
});
