import { createLazyFileRoute } from "@tanstack/react-router";

import { SignInPage } from "@/features/Auth";

export const Route = createLazyFileRoute("/auth/signin")({
  component: SignInPage,
});
