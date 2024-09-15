import { FC } from "react";
import { useNavigate } from "@tanstack/react-router";

import { useAuthStore } from "@/store/authStore";

const _HomePage: FC = () => {
  const isAuthenticated = useAuthStore((state) => state.isAuthenticated);
  const signout = useAuthStore((state) => state.signout);

  const navigate = useNavigate();

  const onSignout = () => {
    signout();
    navigate({ to: "/auth/signin" });
  };

  return (
    <div>
      <h3>HomePage!</h3>
      <p>Your auth state is {isAuthenticated ? "true" : "false"}</p>
      <button onClick={onSignout}>Signout</button>
    </div>
  );
};

const HomePage = _HomePage;

export { HomePage };
