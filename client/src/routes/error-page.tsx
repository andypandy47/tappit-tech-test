import { useRouteError } from "react-router-dom";

const ErrorPage = () => {
  const error: unknown = useRouteError();
  console.error(error);

  return (
    <main className="flex h-full justify-center bg-slate-50 py-16">
      <div id="error-page" className="w-[800px]">
        <h1 className="mb-6 text-6xl">Oops!</h1>
        <p className="mb-6 text-3xl">An unexpected error has occurred</p>
        <p className="text-6xl">
          {(error as Error)?.message || (error as { status?: number })?.status}
        </p>
      </div>
    </main>
  );
};

export default ErrorPage;
