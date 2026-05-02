function mas(m, k, b, x0, v0)

clc;

fprintf("=== Movimiento Armónico Amortiguado ===\n\n");

lambda = b / (2*m);
omega = sqrt(k/m);

fprintf("lambda = %.4f\n", lambda);
fprintf("omega  = %.4f\n\n", omega);

if lambda^2 > omega^2
    tipo = "Sobreamortiguado";
elseif lambda^2 == omega^2
    tipo = "Criticamente amortiguado";
else
    tipo = "Subamortiguado";
end

fprintf("Tipo de sistema: %s\n\n", tipo);

t = linspace(0,10,200);

if lambda^2 > omega^2

    r1 = -lambda + sqrt(lambda^2 - omega^2);
    r2 = -lambda - sqrt(lambda^2 - omega^2);

    fprintf("Raices:\n");
    fprintf("r1 = %.4f\n", r1);
    fprintf("r2 = %.4f\n\n", r2);

    A = [1 1; r1 r2];
    B = [x0; v0];

    C = A\B;

    C1 = C(1);
    C2 = C(2);

    fprintf("Constantes:\n");
    fprintf("C1 = %.4f\n", C1);
    fprintf("C2 = %.4f\n\n", C2);

    if C2 >= 0
        fprintf("x(t) = %.4f*e^(%.4ft) + %.4f*e^(%.4ft)\n\n", C1, r1, C2, r2);
    else
        fprintf("x(t) = %.4f*e^(%.4ft) - %.4f*e^(%.4ft)\n\n", C1, r1, abs(C2), r2);
    end

    x = C1*exp(r1*t) + C2*exp(r2*t);

elseif lambda^2 == omega^2

    C1 = x0;
    C2 = v0 + lambda*x0;

    fprintf("Constantes:\n");
    fprintf("C1 = %.4f\n", C1);
    fprintf("C2 = %.4f\n\n", C2);

    fprintf("x(t) = (%.4f + %.4ft)e^(%.4ft)\n\n", C1, C2, -lambda);

    x = (C1 + C2*t).*exp(-lambda*t);

else

    wd = sqrt(omega^2 - lambda^2);

    C1 = x0;
    C2 = (v0 + lambda*x0)/wd;

    fprintf("Constantes:\n");
    fprintf("C1 = %.4f\n", C1);
    fprintf("C2 = %.4f\n\n", C2);

    fprintf("x(t) = e^(%.4ft)[%.4f*cos(%.4ft) + %.4f*sin(%.4ft)]\n\n", ...
        -lambda, C1, wd, C2, wd);

    x = exp(-lambda*t).*(C1*cos(wd*t) + C2*sin(wd*t));

end

% ================= JSON OUTPUT =================
result.lambda = lambda;
result.omega = omega;
result.tipo = tipo;
result.C1 = C1;
result.C2 = C2;

if exist('r1','var')
    result.r1 = r1;
    result.r2 = r2;
end

result.t = t;
result.x = x;

json = jsonencode(result);

fprintf("JSON_START\n");
fprintf("%s\n", json);
fprintf("JSON_END\n");

end