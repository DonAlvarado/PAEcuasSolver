function result = rlci(L, R, C, E, i0, di0)

t = linspace(0,10,200);

a = L;
b = R;
c = 1/C;

if isnumeric(E)
    f = @(t) E;
else
    f = @(t) eval(E);
end

result = ode2_core(a, b, c, f, t, i0, di0);

end

json = jsonencode(result);

fprintf("JSON_START\n");
fprintf("%s\n", json);
fprintf("JSON_END\n");