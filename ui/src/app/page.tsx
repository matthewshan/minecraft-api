'use client';

import { signIn, signOut, useSession } from "next-auth/react";

export default function Home() {
  // const { data: session } = useSession();

  return (
    <div>
      todo
      {/* {!session ? (
        <button onClick={() => signIn("discord")}>Login with Discord</button>
      ) : (
        <>
          <p>Welcome, {session.user?.name}</p>
          <button onClick={() => signOut()}>Logout</button>
        </>
      )} */}
    </div>
  );
}
