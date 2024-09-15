import { createLazyFileRoute } from "@tanstack/react-router";

import { HomePage } from "@/features/Home";

export const Route = createLazyFileRoute("/_private/")({
  component: HomePage,
});
