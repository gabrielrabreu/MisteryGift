import { FC } from "react";
import { useNavigate } from "@tanstack/react-router";

import { useAuthStore } from "@/store/authStore";

const _SignInPage: FC = () => {
  const isAuthenticated = useAuthStore((state) => state.isAuthenticated);
  const signin = useAuthStore((state) => state.signin);

  const navigate = useNavigate();

  const onSignin = () => {
    signin();
    navigate({ to: "/" });
  };

  return (
    <div>
      <h3>SignInPage!</h3>
      <p>Your auth state is {isAuthenticated ? "true" : "false"}</p>
      <button onClick={onSignin}>Signin</button>
    </div>
  );
};

const SignInPage = _SignInPage;

export { SignInPage };
